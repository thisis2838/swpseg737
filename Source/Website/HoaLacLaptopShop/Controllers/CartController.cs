using HoaLacLaptopShop.Controllers;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CartController : Controller
{
    private readonly HoaLacLaptopShopContext db;

    public CartController(HoaLacLaptopShopContext context)
    {
        db = context;
    }

    public const string CART_KEY = "MYCART";

    public List<CartItem> Cart
    {
        get
        {
            return HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
        }
    }

    public IActionResult Index()
    {
        LoadCartFromDatabase();
        return View(Cart);
    }

    [HttpPost]
    public IActionResult AddToCart(int id, int quantity = 1)
    {
        var userId =  HttpContext.Session.GetString("CurrentUserId");

        if (userId == null)
        {
            return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden } );
        }

        var user = db.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
            return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
        }

        var cart = Cart;
        var item = cart.SingleOrDefault(p => p.id == id);

        // If not found item
        if (item == null)
        {
            var product = db.Products.Include(x => x.ProductImages).SingleOrDefault(p => p.ID == id);
            if (product == null)
            {
                TempData["Message"] = $"Not found product with id {id}";
                return RedirectToAction("Index", "Error", new { type = KnownErrorType.NotFound });
            }

            item = new CartItem
            {
                id = id,
                productName = product.Name,
                price = product.Price,
                quantity = quantity,
                link = product.ProductImages.First().GetProductImageURL()
            };
            cart.Add(item);
        }
        else
        {
            item.quantity += quantity;
        }

        HttpContext.Session.Set(CART_KEY, cart);

        // Save or update order in the database
        SaveOrder(user, cart);

        return RedirectToAction("Index");
    }

    public IActionResult RemoveCart(int id)
    {
        var cart = Cart;
        var item = cart.SingleOrDefault(p => p.id == id);
        if (item != null)
        {
            cart.Remove(item);

            // Update the order in the database
            UpdateOrder(HttpContext.Session.GetString("CurrentUserId"), cart);

            HttpContext.Session.Set(CART_KEY, cart);
        }
        return RedirectToAction("Index");
    }

    public void LoadCartFromDatabase()
    {
        var userId = HttpContext.Session.GetString("CurrentUserId");
        if (string.IsNullOrEmpty(userId))
        {
            return;
        }

        var user = db.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
            return;
        }

        var existingOrder = db.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);

        if (existingOrder != null)
        {
            var cartItems = existingOrder.OrderDetails.Select(od => new CartItem
            {
                id = od.ProductId,
                productName = od.Product.Name,
                link = db.ProductImages.FirstOrDefault(pi => pi.ProductId == od.ProductId)?.GetProductImageURL(),
                price = od.Product.Price,
                quantity = od.Quantity
            })
            .ToList();

            HttpContext.Session.Set(CART_KEY, cartItems);
        }
    }
    // For add to Cart -> Changes in Order and OrderDetails
    private void SaveOrder(User user, List<CartItem> cart)
    {

        // Find existing order in DB
        var existingOrder = db.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);

        if (existingOrder == null)
        {
            // Map data from order and orderDetails to viewModel - CartItem
            existingOrder = new Order
            {
                BuyerID = user.ID,
                Status = OrderStatus.Created,
                //TODO Address = "user address",
                PhoneNumber = user.PhoneNumber,
                OrderTime = DateTime.Now,
                TotalPrice = (decimal)cart.Sum(c => c.total),
                PaymentMethod = PaymentMethod.CashOnDelivery, // // Defeaul Payment
            };

            db.Orders.Add(existingOrder);
        }
        else
        {
            existingOrder.TotalPrice = (decimal)cart.Sum(c => c.total);
        }

        // Update order details. Iterate through cart -> add to orderDetails table
        foreach (var cartItem in cart)
        {
            var orderDetail = existingOrder.OrderDetails.FirstOrDefault(od => od.ProductId == cartItem.id);
            if (orderDetail == null)
            {
                orderDetail = new OrderDetail
                {
                    ProductId = cartItem.id,
                    Quantity = cartItem.quantity,
                };
                existingOrder.OrderDetails.Add(orderDetail);
            }
            else
            {
                orderDetail.Quantity = cartItem.quantity;
            }
        }

        db.SaveChanges();
    }
    // For remove item from cart
    private void UpdateOrder(string userId, List<CartItem> cart)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return;
        }

        var user = db.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
            return;
        }

        var existingOrder = db.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);

        if (existingOrder != null)
        {
            existingOrder.TotalPrice = (decimal)cart.Sum(c => c.total);

            // Update or remove order details
            foreach (var orderDetail in existingOrder.OrderDetails.ToList())
            {
                var cartItem = cart.SingleOrDefault(c => c.id == orderDetail.ProductId);
                if (cartItem == null)
                {
                    db.OrderDetails.Remove(orderDetail);
                }
                else
                {
                    orderDetail.Quantity = cartItem.quantity;
                }
            }

            db.SaveChanges();
        }
    }
}
