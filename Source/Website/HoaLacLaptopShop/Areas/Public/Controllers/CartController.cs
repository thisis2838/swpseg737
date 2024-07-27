using AngleSharp.Attributes;
using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    [Authorize]
    public class CartController : OrdersController
    {
        protected override bool AutoRefreshPrices => true;

        public CartController(HoaLacLaptopShopContext context) : base(context)
        { }

        public IActionResult Index()
        {
            return View(Cart);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ModifyQuantity(int productID, int difference = 1)
        {
            if (!HttpContext.IsLoggedIn())
            {
                this.AddError("Please login before buying products!");
                return RedirectToAction("Index", "Home");
            }

            var product = Context.EnabledProducts.Include(x => x.ProductImages).SingleOrDefault(x => x.ID == productID);
            if (product is null)
            {
                this.AddError("The requested product could not be found.");
                return NotFound();
            }
            if (difference == 0)
            {
                this.AddError("Invalid quantity requested.");
                return RedirectToAction(nameof(Index));
            }
            
            var user = HttpContext.GetCurrentUser()!;
            var cart = Cart;
            int actualQty = 0;

            var item = cart.OrderDetails.SingleOrDefault(x => x.ProductId == product.ID);
            // If not found item
            if (item is null)
            {
                if (product.Stock == 0)
                {
                    this.AddError("The requested product was out of stock.");
                    return RedirectToAction(nameof(Index));
                }
                if (difference < 0)
                {
                    this.AddError("Invalid quantity requested for adding to cart.");
                    return RedirectToAction(nameof(Index));
                }

                actualQty = Math.Min(product.Stock, difference);
                cart.OrderDetails.Add(new OrderDetail()
                {
                    Product = product,
                    Quantity = actualQty
                });
            }
            else
            {
                if (product.Stock == 0)
                {
                    this.AddWarning("The requested product was out of stock and was removed from the cart.");
                    return RedirectToAction(nameof(RemoveFromCart), new { productID });
                }

                var newQty = item.Quantity += actualQty;
                // we're erasing this item from cart due to quantity being plunged to below 0
                if (newQty < 0)
                {
                    this.AddWarning("The product was removed from the cart as the requested quantity was equal to below 0.");
                    return RedirectToAction(nameof(RemoveFromCart), new { productID });
                }

                actualQty = Math.Min(product.Stock, difference + item.Quantity) - item.Quantity;
                item.Quantity += actualQty;
            }

            if (actualQty != difference)
            {
                if (actualQty == 0)
                {
                    this.AddError($"Couldn't increase the quantity of the order due to product shortage.");
                }
                else
                {
                    this.AddWarning($"Only {actualQty} units were added to the order due to product shortage.");
                }
            }
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize, HttpPost]
        public IActionResult RemoveFromCart(int productID)
        {
            if (!Context.Products.Any(x => x.ID == productID))
            {
                this.AddError("The requested product could not be found.");
            }
            else
            {
                var item = Cart.OrderDetails.FirstOrDefault(x => x.ProductId == productID);
                if (item is null)
                {
                    this.AddWarning("The requested product had not been added to the cart.");
                }
                else
                {
                    this.AddMessage("Removed item from cart.");
                    Cart.OrderDetails.Remove(item);
                    Context.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}