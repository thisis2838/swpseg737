using HoaLacLaptopShop.Areas.Public.Controllers;
using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CartController : Controller
{
    private readonly HoaLacLaptopShopContext _context;

    public CartController(HoaLacLaptopShopContext context)
    {
        _context = context;
    }

    public const string CART_KEY = "MYCART";
    public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();

    public IActionResult Index()
    {
        LoadCartFromDatabase();
        return View(Cart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddToCart(int id, int quantity = 1)
    {
        var user = HttpContext.GetCurrentUser()!;
        var cart = Cart;
        var item = cart.SingleOrDefault(p => p.ID == id);

        // If not found item
        if (item == null)
        {
            var product = _context.Products.Include(x => x.ProductImages).SingleOrDefault(p => p.ID == id);
            if (product == null)
            {
                this.SetError("Product could not be found to add to cart!");
                return NotFound();
            }

            item = new CartItem
            {
                ID = id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                ThumbnailLink = product.ProductImages.First().GetProductImageURL()
            };
            cart.Add(item);
        }
        else
        {
            item.Quantity += quantity;
        }

        HttpContext.Session.Set(CART_KEY, cart);

        // Save or update order in the database
        SaveOrder(cart);
        return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public IActionResult RemoveCart(int id)
    {
        var cart = Cart;
        var item = cart.SingleOrDefault(p => p.ID == id);
        if (item != null)
        {
            cart.Remove(item);

            // Update the order in the database
            UpdateOrder(cart);
            HttpContext.Session.Set(CART_KEY, cart);
        }
        return RedirectToAction("Index");
    }

    private void LoadCartFromDatabase()
    {
        var user = HttpContext.GetCurrentUser()!;
        var existingOrder = _context.Orders
            .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);
        if (existingOrder != null)
        {
            var cartItems = existingOrder.OrderDetails.Select(od => new CartItem
            {
                ID = od.ProductId,
                ProductName = od.Product.Name,
                ThumbnailLink = _context.ProductImages.FirstOrDefault(pi => pi.ProductId == od.ProductId)!.GetProductImageURL(),
                Price = od.Product.Price,
                Quantity = od.Quantity
            })
            .ToList();

            HttpContext.Session.Set(CART_KEY, cartItems);
        }
    }

    // For add to Cart -> Changes in Order and OrderDetails
    [Authorize]
    private void SaveOrder(List<CartItem> cart)
    {
        var user = HttpContext.GetCurrentUser()!;
        // Find existing order in DB
        var existingOrder = _context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);

        if (existingOrder == null)
        {
            // Map data from order and orderDetails to viewModel - CartItem
            existingOrder = new Order
            {
                BuyerID = user.ID,
                Status = OrderStatus.Created,
                District = "",
                Province = "",
                Ward = "",
                Street = "",
                RecipientName = user.Name,
                PhoneNumber = user.PhoneNumber,
                OrderTime = DateTime.Now,
                TotalPrice = (decimal)cart.Sum(c => c.Total),
                PaymentMethod = PaymentMethod.CashOnDelivery, // // Defeaul Payment
            };

            _context.Orders.Add(existingOrder);
        }
        else
        {
            existingOrder.TotalPrice = (decimal)cart.Sum(c => c.Total);
        }

        // Update order details. Iterate through cart -> add to orderDetails table
        foreach (var cartItem in cart)
        {
            var orderDetail = existingOrder.OrderDetails.FirstOrDefault(od => od.ProductId == cartItem.ID);
            if (orderDetail == null)
            {
                orderDetail = new OrderDetail
                {
                    ProductId = cartItem.ID,
                    Quantity = cartItem.Quantity,
                    ProductPrice = (int)cartItem.Price
                };
                existingOrder.OrderDetails.Add(orderDetail);
            }
            else
            {
                orderDetail.Quantity = cartItem.Quantity;
            }
        }

        _context.SaveChanges();
    }
    // For remove item from cart
    [Authorize]
    private void UpdateOrder(List<CartItem> cart)
    {
        var user = HttpContext.GetCurrentUser()!;
        var existingOrder = _context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault(o => o.BuyerID == user.ID && o.Status == OrderStatus.Created);

        if (existingOrder != null)
        {
            existingOrder.TotalPrice = (decimal)cart.Sum(c => c.Total);

            // Update or remove order details
            foreach (var orderDetail in existingOrder.OrderDetails.ToList())
            {
                var cartItem = cart.SingleOrDefault(c => c.ID == orderDetail.ProductId);
                if (cartItem == null)
                {
                    _context.OrderDetails.Remove(orderDetail);
                }
                else
                {
                    orderDetail.Quantity = cartItem.Quantity;
                }
            }

            _context.SaveChanges();
        }
    }
}
