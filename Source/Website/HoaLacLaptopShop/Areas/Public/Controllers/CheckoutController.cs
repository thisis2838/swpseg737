using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Helpers;
using Azure.Core;
using HoaLacLaptopShop.Areas.Public.Controllers;
using HoaLacLaptopShop.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Services;
using HoaLacLaptopShop.Areas.Shared.ViewModels;

public class CheckoutController : Controller
{
    private readonly HoaLacLaptopShopContext _context;
    private readonly IVnPayService _vnPayService;

    public CheckoutController(HoaLacLaptopShopContext context, IVnPayService vnPayService)
    {
        _context = context;
        _vnPayService = vnPayService;

    }

    [HttpGet]
    public IActionResult Index()
    {
        var userId = HttpContext.GetCurrentUserID()!;

        // Find the order associated with the current user
        var order = _context.Orders
            .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)  // Include related OrderItems
            .Include(o => o.Buyer)       // Include related Buyer
            .SingleOrDefault(o => o.BuyerID.ToString() == userId.ToString() && o.Status == OrderStatus.Created);

        if (order is null)
        {
            this.SetError("Please purchase some items first before checking out.");
            return RedirectToAction("Index", "Cart");
        }

        return View(order);
    }

    [HttpPost]
    public IActionResult ConfirmOrder
    (
        string name, string phone,
        string address, string city, string district, string ward,
        PaymentMethod paymentMethod, string voucherCode
    )
    {
        var user = HttpContext.GetCurrentUser()!;
        var cartItems = HttpContext.Session.Get<List<CartItem>>(CartController.CART_KEY) ?? new List<CartItem>();
        var order = _context.Orders
            .Include(o => o.OrderDetails)
            .Include(o => o.Buyer)
            .SingleOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);
        if (!cartItems.Any() || order is null)
        {
            this.SetError("Please purchase some items first before checking out.");
            return RedirectToAction("Index", "Cart");
        }

        try
        {
            if (paymentMethod == PaymentMethod.Online)
            {
                var VnPayModel = new VnPayRequestModel
                {
                    OrderId = new Random().Next(1000, 10000),
                    Amount = order.OrderDetails.Sum(oi => oi.SubTotal),
                    CreatedDate = DateTime.Now,
                    Description = $"{order.Buyer.Name} {order.Buyer.PhoneNumber}"
                };
                return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, VnPayModel));
            }
            _context.Database.BeginTransaction();
            ProcessOrder(name, phone, address, city, district, ward, paymentMethod, voucherCode, cartItems, order);

            _context.Database.CommitTransaction();
            // Clear the cart after confirming the order
            HttpContext.Session.Remove(CartController.CART_KEY);

            this.SetMessage("Order has been placed successfully!");
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Home");
        }
    }

    private void ProcessOrder(string name, string phone, string address, string city, string district, string ward, PaymentMethod paymentMethod, string voucherCode, List<CartItem> cartItems, Order? order)
    {
        order.Status = OrderStatus.Delivering; // Change status to delivering
        order.RecipientName = name;
        // Set the corresponding locations
        order.Province = city;
        order.District = district;
        order.Ward = ward;
        order.Street = address;
        order.PhoneNumber = phone;
        order.OrderTime = DateTime.Now;
        order.PaymentMethod = paymentMethod;
        // Handling voucherId
        var voucher = _context.Vouchers.SingleOrDefault(v => v.Code == voucherCode);
        order.TotalPrice = order.OrderDetails.Sum(oi => oi.SubTotal);
        order.VoucherID = voucher != null ? voucher.ID : null;
        order.DiscountedPrice = voucher != null ? CalculateDiscount(voucher, order.OrderDetails.Sum(oi => oi.SubTotal)) : 0;

        foreach (var cartItem in cartItems)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == cartItem.ID);
            if (product == null)
            {
                this.SetError("A product in your order could not be found.");
                //return RedirectToAction("Index", "Cart");
            }
            product.Stock -= cartItem.Quantity;
            // Decrease the product quantity
        }
        _context.SaveChanges();
    }

    [HttpPost]
    public IActionResult CheckVoucher([FromBody] VoucherRequest request)
    {
        var userId = HttpContext.GetCurrentUserID()!;
        var voucher = _context.Vouchers.SingleOrDefault(v => v.Code == request.voucherCode);
        JsonResult invalid(String issue)
        {
            return Json(new
            {
                valid = false,
                discount = 0,
                issue = issue
            });
        }

        bool checkExpired = DateTime.Now.Date <= voucher.ExpiryDate.ToDateTime(new TimeOnly());
        if (!checkExpired) return invalid("Voucher has expired");
        var existInOrder = _context.Orders.Any(o => o.VoucherID == voucher.ID && o.BuyerID == userId) && checkExpired;
        if (existInOrder) return invalid("You already used this voucher");

        if (voucher == null)
        {
            return invalid("Invalid Voucher");
        }

        decimal discount = CalculateDiscount(voucher, request.subTotal);
        if (discount == 0) return invalid("Please buy more!");

        return Json(new { valid = true, discount = discount });
    }

    private bool CheckVoucherCode(Voucher voucher, int userId)
    {
        // Your logic to check if the voucher code is valid
        // Return true if valid, false otherwise
        return DateTime.Now.Date <= voucher.ExpiryDate.ToDateTime(new TimeOnly()) &&
            !(_context.Orders.Any(o => o.VoucherID == voucher.ID && o.BuyerID == userId));
    }

    private decimal CalculateDiscount(Voucher voucher, decimal subtotal)
    {
        if (subtotal < voucher.MinimumOrderPrice)
        {
            return 0;
        }

        if (voucher.IsPercentageDiscount)
        {
            return subtotal * (voucher.DiscountValue / 100);
        }
        else
        {
            return voucher.DiscountValue;
        }
    }
    public IActionResult OrderConfirmation(int orderId)
    {
        var order = _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefault(o => o.ID == orderId);

        if (order == null)
        {
            return Redirect("/404");
        }

        return View(order);
    }

    [Authorize]
    public IActionResult PaymentSuccess()
    {
        return View("Success");
    }
    [Authorize]
    public IActionResult PaymentFail()
    {
        return View();
    }

    [Authorize]
    public IActionResult PaymentCallback()
    {
        var response = _vnPayService.PaymentExecute(Request.Query);

        if (response == null || response.VnPayResponseCode != "00")
        {
            TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";
            return RedirectToAction("PaymentFail");
        }

        TempData["Message"] = $"Thanh toán VNPay thành công";
        return RedirectToAction("PaymentSuccess");

    }

}
