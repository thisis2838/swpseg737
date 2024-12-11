using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public abstract class OrdersController : Controller
    {
        protected HoaLacLaptopShopContext Context { get; private init; }
        protected abstract bool AutoRefreshPrices { get; }

        private Order _cart = null!;
        protected Order Cart
        {
            get
            {
                if (_cart != null) return _cart;

                var existing = Context.Orders
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImages)
                    .Include(x => x.Buyer)
                    .FirstOrDefault(x => x.BuyerID == HttpContext.GetCurrentUserID()!.Value && x.Status == OrderStatus.Created);
                if (existing is null)
                {
                    existing = new Order()
                    {
                        BuyerID = HttpContext.GetCurrentUserID()!.Value,
                        Status = OrderStatus.Created,
                        RecipientName = HttpContext.GetCurrentUser()!.Name,
                        PhoneNumber = HttpContext.GetCurrentUser()!.PhoneNumber,
                        PaymentMethod = PaymentMethod.CashOnDelivery,
                        OrderTime = DateTime.Now,
                        Province = "", District = "", Ward = "", Street = ""
                    };
                    Context.Orders.Add(existing);
                    Context.SaveChanges();
                }
                else
                {
                    foreach (var item in existing.OrderDetails)
                    {
                        // update product prices now if they're the default
                        // or if we want to refresh the prices
                        if (item.ProductPrice == default || AutoRefreshPrices)
                            item.ProductPrice = item.Product.Price;
                    }
                    existing.TotalPrice = existing.OrderDetails.Sum(x => x.SubTotal);
                    Context.SaveChanges();
                }

                _cart = existing;
                return existing;
            }
        }

        protected OrdersController(HoaLacLaptopShopContext context)
        {
            Context = context;
        }

        protected void RefreshPrices()
        {
            foreach (var item in Cart.OrderDetails)
            {
                item.ProductPrice = item.Product.Price;
            }
            Cart.TotalPrice = Cart.OrderDetails.Sum(x => x.SubTotal);
            Context.SaveChanges();
        }
    }
}
