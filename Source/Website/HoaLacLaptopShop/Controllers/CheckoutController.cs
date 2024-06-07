using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Models;
using System.Linq;
using HoaLacLaptopShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Controllers;
using Azure.Core;

public class CheckoutController : Controller
{
    private readonly HoaLacLaptopShopContext _context;

    public CheckoutController(HoaLacLaptopShopContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetString("CurrentUserId");
        if (userId == null)
        {
            return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
        }

        // Find the order associated with the current user
        var order = _context.Orders
            .Include(o => o.OrderDetails)  // Include related OrderItems
                .ThenInclude(oi => oi.Product)
            .Include(o => o.Buyer)       // Include related Buyer
            .SingleOrDefault(o => o.BuyerID.ToString() == userId && o.Status == OrderStatus.Created);

        if (order == null)
        {
            return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
        }

        return View(order);
    }

    [HttpPost]
    public IActionResult ConfirmOrder(string name, string email, string phone, string address, string city, String totalPrice, string district, PaymentMethod paymentMethod, String voucherCode)
    {
        var userId =  HttpContext.Session.GetString("CurrentUserId");
        if (userId == null)
        {
            return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
        }

        var user = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
             return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
        }

        var cartItems = HttpContext.Session.Get<List<CartItem>>(CartController.CART_KEY) ?? new List<CartItem>();
        if (!cartItems.Any())
        {
            TempData["Message"] = "Your cart is empty!";
            return RedirectToAction("Index", "Cart");
        }

        var order = _context.Orders.SingleOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);
        order.Status = OrderStatus.Delivering; // Change status to delivering
        order.Province = city;
        order.District = district;
        //TODO order.Address = $"{address}, {district}, {city}"; // Adjusted address format
        order.PhoneNumber = phone;
        order.OrderTime = DateTime.Now;
        order.PaymentMethod = paymentMethod;
        // Handling voucherId
        var voucher = _context.Vouchers.SingleOrDefault(v => v.Code == voucherCode);
        order.TotalPrice = decimal.Parse(totalPrice);
        order.VoucherID = voucher != null ? voucher.ID : null;
        foreach (var cartItem in cartItems)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == cartItem.id);
            if (product == null)
            {
                TempData["Message"] = $"Product with id {cartItem.id} not found!";
                return RedirectToAction("Index", "Cart");
            }
            product.Stock -= cartItem.quantity;
            // Decrease the product quantity
        }
        _context.SaveChanges();

        // Clear the cart after confirming the order
        HttpContext.Session.Remove(CartController.CART_KEY);

        TempData["Message"] = "Order has been placed successfully!";
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult CheckVoucher([FromBody] VoucherRequest request)
    {
        var voucher = _context.Vouchers.SingleOrDefault(v => v.Code == request.VoucherCode);
        if (voucher == null || !CheckVoucherCode(voucher))
        {
            return Json(new { valid = false, discount = 0 });
        }

        decimal discount = CalculateDiscount(voucher, request.Subtotal);
        return Json(new { valid = true, discount = discount });
    }
    private bool CheckVoucherCode(Voucher voucher)
    {
        // Your logic to check if the voucher code is valid
        // Return true if valid, false otherwise
        return DateTime.Now.Date <= voucher.ExpiryDate.ToDateTime(new TimeOnly());
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
}
