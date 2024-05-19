using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Controllers
{
    public class CartController : Controller
    {
        private readonly HoaLacLaptopShopContext db;

        public CartController(HoaLacLaptopShopContext context)
        {
            db = context;
        }
        const string CART_KEY = "MYCART";
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
   
        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.id == id);
            // If not found item
            if (item == null)
            {
                var product = db.Products.SingleOrDefault(p => p.ID == id);
                if (product == null)
                {
                    TempData["Message"] = $"Not found product with id {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    id = id,
                    productName = product.Name,
                    price = product.Price,
                    quantity = quantity,
                    // Link of image: First image link in productImages table
                    link = db.ProductImages.Where(pi => pi.ProductId == id).ToList()[0].Link ?? String.Empty,
                };
                cart.Add(item);
            }
            else
            {
                item.quantity += quantity;
            }
            HttpContext.Session.Set(CART_KEY, cart);

            return RedirectToAction("Index");
        }  
    }
}
