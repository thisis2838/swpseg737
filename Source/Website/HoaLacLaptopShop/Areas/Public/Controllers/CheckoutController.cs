using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.ThirdParty.VNPay;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.CodeAnalysis;
using HoaLacLaptopShop.Filters;
using System.Xml;
using System.Data;
using System.Diagnostics;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class CheckoutController : OrdersController
    {
        protected override bool AutoRefreshPrices => false;

        private readonly IVnPayService _vnPayService;

        public CheckoutController(HoaLacLaptopShopContext context, IVnPayService vnPayService) : base(context)
        {
            _vnPayService = vnPayService;
        }

        [HttpGet, Authorize]
        public IActionResult Index()
        {
            if (!CheckCartIntegrity())
            {
                return RedirectToAction(nameof(CartController.Index), "Cart");
            }
            RefreshPrices();
            return View(Cart);
        }


        [HttpPost, Authorize]
        [ModelStateInclude
        (
            nameof(Order.RecipientName), nameof(Order.PhoneNumber),
            nameof(Order.Province), nameof(Order.District), nameof(Order.Ward), nameof(Order.Street),
            nameof(Order.PaymentMethod)
        )]
        public IActionResult ConfirmOrder(Order vm, string? voucherCode)
        {
            if (!CheckCartIntegrity())
            {
                return RedirectToAction(nameof(CartController.Index), "Cart");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CheckoutController.Index));
            }

            Voucher? voucher = null;
            if (voucherCode != null)
            {
                voucher = Context.Vouchers.FirstOrDefault(x => x.Code.ToLower() == voucherCode.ToLower());
                if (voucher is null || voucher.IsDisabled || voucher.ExpiryDate < DateTime.Now)
                {
                    this.AddError("Unknown voucher code, or voucher was unusable.");
                    return RedirectToAction(nameof(CheckoutController.Index));
                }
                if (HasUsedVoucher(voucher))
                {
                    this.AddError("You cannot use this voucher as you've already used it once before!");
                    return RedirectToAction(nameof(CheckoutController.Index));
                }
            }
            try
            {
                Context.Database.BeginTransaction();
                ProcessOrder(vm, voucher);
                Context.Database.CommitTransaction();

                // FIXME: we shouldn't be saving data before payment becuase products
                // may become unavailable while the customer is finishing the invoice
                if (vm.PaymentMethod == PaymentMethod.Online)
                {
                    var VnPayModel = new VnPayRequestModel
                    {
                        OrderId = Cart.ID,
                        Amount = (double)Cart.TotalPrice,
                        CreatedDate = DateTime.Now,
                        Description = $"hoalaclaptops order #{Cart.ID} by {Cart.Buyer.Name}, {Cart.Buyer.PhoneNumber}"
                    };
                    return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, VnPayModel));
                }
                else
                {
                    this.AddMessage("Order has been placed successfully!");
                    return RedirectToAction(nameof(AccountController.OrderDetails), "Account", new { id = Cart.ID });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                Context.Database.RollbackTransaction();
                this.AddError
                (
                    "A concurrency error was encountered while processing your order. " +
                    "Someone might've bought the the last available units of your desired products. " +
                    "Please recheck your cart and try again."
                );
                return RedirectToAction(nameof(CheckoutController.Index));
            }
            catch (Exception ex)
            {
                this.AddError("An unknown error was encountered " + ex.Message);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


        [HttpPost]
        public IActionResult CheckVoucher([FromBody] VoucherRequest request)
        {
            var userId = HttpContext.GetCurrentUserID()!;
            var voucher = Context.Vouchers.SingleOrDefault(v => v.Code.ToLower() == request.voucherCode.ToLower());
            JsonResult invalid(String issue)
            {
                return Json(new
                {
                    valid = false,
                    discount = 0,
                    issue = issue
                });
            }
            if (voucher == null || voucher.IsDisabled)
            {
                return invalid("Invalid voucher code. Please check your input and try again.");
            }

            if (voucher.ExpiryDate < DateTime.Now)
                return invalid("Voucher is unusable as it has expired.");
            var existInOrder = Context.Orders.Any(o => o.VoucherID == voucher.ID && o.BuyerID == userId);
            if (existInOrder)
                return invalid("You have already used this voucher in the past.");
            if (Cart.TotalPrice < voucher.MinimumOrderPrice) 
                return invalid("Your order's total price is below the minimum applicable price for this voucher. Please purchase more.");
            decimal discount = CalculateDiscount(voucher, Cart.TotalPrice);
            if (discount == 0)
                this.AddWarning("The requested voucher was applied, but won't discount anything.");

            return Json(new { valid = true, discount = discount });
        }

        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                this.AddMessage($"VNPay error encountered{(response is null ? "" : ($" (code: {response.VnPayResponseCode})"))}");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Extract OrderId from the OrderInfo
            var orderInfo = response.OrderDescription; // "Thanh toan don hang: OrderId"
            var orderIdString = orderInfo.Split(':').Last().Trim();
            if (!int.TryParse(orderIdString, out int orderId))
            {
                this.AddMessage("VNPay error encountered: Invalid order ID.");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var order = Context.Orders.FirstOrDefault(o => o.ID == orderId);
            Trace.Assert(order != null);

            order.PaymentMethod = PaymentMethod.Online;
            order.OrderTime = DateTime.Now;
            order.Status = OrderStatus.Delivering; // Mark order as completed
            Context.SaveChanges();

            this.AddMessage("Order successfully placed and paid for through VNPay.");
            return RedirectToAction(nameof(AccountController.OrderDetails), "Account", new { id = orderId });
        }

        [NonAction]
        private void ProcessOrder(Order newInfo, Voucher? voucher)
        {
            foreach (var item in Cart.OrderDetails)
            {
                item.Product.Stock -= item.Quantity;
            }

            // Change status to delivering
            Cart.Status = OrderStatus.Delivering; 
            // Handle recipient
            Cart.RecipientName = newInfo.RecipientName;
            Cart.PhoneNumber = newInfo.PhoneNumber;

            // Set destination
            Cart.Province = newInfo.Province;
            Cart.District = newInfo.District;
            Cart.Ward = newInfo.Ward;
            Cart.Street = newInfo.Street;
            Cart.OrderTime = DateTime.Now;
            Cart.PaymentMethod = newInfo.PaymentMethod;

            // Handle total price & discount
            Cart.Voucher = voucher;
            Cart.TotalPrice = Cart.OrderDetails.Sum(oi => oi.SubTotal);
            Cart.DiscountedPrice = Cart.TotalPrice - (voucher != null ? CalculateDiscount(voucher, Cart.TotalPrice) : 0);

            Context.SaveChanges();
        }
        [NonAction]
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
        [NonAction]
        private bool HasUsedVoucher(Voucher voucher)
        {
            var user = Context.Users.Include(x => x.Orders).FirstOrDefault(x => x.ID == HttpContext.GetCurrentUserID()!);
            return user!.Orders.Any(x => x.Voucher != null && x.Voucher.ID == voucher.ID);
        }
        [NonAction]
        private bool CheckCartIntegrity()
        {
            var cart = Cart;
            if (cart.OrderDetails.Count == 0)
            {
                this.AddError("Please purchase some items first before checking out.");
                return false;
            }

            bool good = true;
            for (int i = 0; i < cart.OrderDetails.Count; i++)
            {
                var item = cart.OrderDetails.ElementAt(i);
                if (item.Product.IsDisabled)
                {
                    this.AddError($"Item '{item.Product.Name}' was no longer purchasable and was removed from your cart.");
                    cart.OrderDetails.Remove(item);
                }
                else if (item.Product.Stock == 0)
                {
                    this.AddError($"Item '{item.Product.Name}' was no longer in stock and was removed from your cart.");
                    cart.OrderDetails.Remove(item);
                }
                else if (item.Product.Stock < item.Quantity)
                {
                    this.AddError($"Item '{item.Product.Name}' had its quantity reduced to fit your demand.");
                    item.Quantity = item.Product.Stock;
                }
                else continue;

                good = false;
            }

            Context.SaveChanges();

            if (!good)
            {
                this.AddWarning
                (
                    "Your cart has been re-adjusted according to the availability of items. " +
                    "Please double check the items and proceed to checkout process again when ready."
                );
            }
            return good;
        }

    }
}