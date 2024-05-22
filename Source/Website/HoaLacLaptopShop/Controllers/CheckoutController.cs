using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Models;
using System.Linq;
using HoaLacLaptopShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Helpers;

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
        var userId = "1";// HttpContext.Session.GetString("DefaultUserId");
        if (userId == null)
        {
            return RedirectToAction("Error403", "Error");
        }

        var user = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
            return RedirectToAction("Error403", "Error");
        }

        var cartItems = HttpContext.Session.Get<List<CartItem>>(CartController.CART_KEY) ?? new List<CartItem>();

        var model = new CheckoutViewModel
        {
            Name = user.Name,
            Email = user.Email,
            Phone = user.PhoneNumber,
            CartItems = cartItems
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult ConfirmOrder(string name, string email, string phone, string address, string city, string district, PaymentMethod paymentMethod)
    {
        var userId = "1";// HttpContext.Session.GetString("DefaultUserId");
        if (userId == null)
        {
            return RedirectToAction("Error403", "Error");
        }

        var user = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
             return RedirectToAction("Error403", "Error");
        }

        var cartItems = HttpContext.Session.Get<List<CartItem>>(CartController.CART_KEY) ?? new List<CartItem>();
        if (!cartItems.Any())
        {
            TempData["Message"] = "Your cart is empty!";
            return RedirectToAction("Index", "Cart");
        }

        var order = _context.Orders.SingleOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);
        order.Status = OrderStatus.Delivering; // Change status to delivering
        order.Address = $"{address}, {city}, {district}"; // Adjusted address format
        order.PhoneNumber = phone;
        order.CreationTime = DateTime.Now;
        order.TotalPrice = (float)cartItems.Sum(c => c.total);
        order.PaymentMethod = paymentMethod;

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
