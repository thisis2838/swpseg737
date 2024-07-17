using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

[Area("Administration")]
public class VoucherController : Controller
{
    private readonly HoaLacLaptopShopContext _context;

    public VoucherController(HoaLacLaptopShopContext context)
    {
        _context = context;
    }

    // GET: Voucher/Index
    public async Task<IActionResult> Index(string filter)
    {
        var userId = HttpContext.Session.GetString("CurrentUserId");

        if (userId == null)
        {
            return RedirectToAction("Error403", "Error");
        }

        var user = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (user == null)
        {
            return RedirectToAction("Error403", "Error");
        }

        var currentUser = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
        if (currentUser != null && currentUser.IsSales == false)
        {
            return RedirectToAction("Error403", "Error");
        }
        var vouchers = from v in _context.Vouchers select v;
        ViewData["CurrentFilter"] = filter;
        // Filter based on the expiration date
        if (!String.IsNullOrEmpty(filter))
        {
            if (filter == "Expired")
            {
                vouchers = vouchers.Where(v => v.ExpiryDate < DateOnly.FromDateTime(DateTime.Now));
            }
            else if (filter == "Available")
            {
                vouchers = vouchers.Where(v => v.ExpiryDate < DateOnly.FromDateTime(DateTime.Now));
            }
        }
        return View(await vouchers.ToListAsync());
    }
    //GET Voucher/Detail

    public async Task<IActionResult> Detail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voucher = await _context.Vouchers.FirstOrDefaultAsync(m => m.ID == id);

        if (voucher == null)
        {
            return NotFound();
        }

        var usedTime = await GetVoucherUsageCountAsync(id.Value);
        ViewBag.UsedTime = usedTime;
        var orders = await _context.Orders.Where(o => o.VoucherID == id).ToListAsync();
        ViewBag.Orders = orders;
        return View(voucher);
    }

    // GET: Voucher/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Voucher/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Code,MinimumOrderPrice,DiscountValue,IsPercentageDiscount,ExpiryDate")] Voucher voucher)
    {
        if (ModelState.IsValid)
        {
            var issuerId = HttpContext.Session.GetString("CurrentUserId");         
            if (int.TryParse(issuerId, out int parsedIssuerId))
            {
                voucher.IssuerId = parsedIssuerId;
            }
            else
            {
                ModelState.AddModelError("IssuerId", "Cannot determine the issuer ID.");
                return View(voucher);
            }
            bool codeExists = await _context.Vouchers.AnyAsync(v => v.Code == voucher.Code && v.ID != voucher.ID);
            if (codeExists)
            {
                ModelState.AddModelError("Code", "Voucher code already exists.");
                return View(voucher);
            }
            try
            {
                _context.Update(voucher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(voucher.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
       
        return View(voucher);
    }

    // GET: Voucher/Update
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var voucher = await _context.Vouchers.FindAsync(id);
        if (voucher == null)
        {
            return NotFound();
        }
        return View(voucher);
    }

    // POST: Voucher/Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("ID,Code,MinimumOrderPrice,DiscountValue,IsPercentageDiscount,ExpiryDate,IssuerId")] Voucher updatedVoucher)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(updatedVoucher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(updatedVoucher.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(updatedVoucher);
    }

    // GET: Voucher/Delete
    public async Task<IActionResult> Delete(int id)
    {
        var voucher = await _context.Vouchers
            .FirstOrDefaultAsync(m => m.ID == id);
        if (voucher == null)
        {
            return NotFound();
        }

        return View(voucher);
    }

    // POST: Voucher/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var voucher = await _context.Vouchers.FindAsync(id);
        _context.Vouchers.Remove(voucher);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    //GET: Voucher/TimeUsed
    public async Task<int> GetVoucherUsageCountAsync(int voucherId)
    {
        if (voucherId == null)
        {
            return 0;
        }
        var usageCount = await _context.Orders.CountAsync(o => o.VoucherID == voucherId);
        return usageCount;
    }
    //GET: Voucher/Index
    private bool VoucherExists(int id)
    {
        return _context.Vouchers.Any(e => e.ID == id);
    }
    // GET: Voucher/Search
    public async Task<IActionResult> Search(string query, string sortOrder)
    {
       
        var vouchers = from v in _context.Vouchers
                       select v;

        if (!String.IsNullOrEmpty(query))
        {
            vouchers = vouchers.Where(s => s.Code.Contains(query) || s.IssuerId.ToString().Contains(query));
        }

        

        return View("Index", await vouchers.ToListAsync());
    }
}