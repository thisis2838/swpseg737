using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

[Area("Administration")]
[Authorize(Roles = "Marketing")]
public class VoucherController : Controller
{
    private readonly HoaLacLaptopShopContext _context;

    public VoucherController(HoaLacLaptopShopContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? filter)
    {
        var vouchers = from v in _context.Vouchers select v;
        ViewData["CurrentFilter"] = filter;
        // Filter based on the expiration date
        if (!String.IsNullOrEmpty(filter))
        {
            if (filter == "Expired")
            {
                vouchers = vouchers.Where(v => v.ExpiryDate < DateTime.Now);
            }
            else if (filter == "Available")
            {
                vouchers = vouchers.Where(v => v.ExpiryDate < DateTime.Now);
            }
        }
        return View(await vouchers.ToListAsync());
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ModelStateInclude
    (
        nameof(Voucher.Code),
        nameof(Voucher.MinimumOrderPrice),
        nameof(Voucher.DiscountValue),
        nameof(Voucher.IsPercentageDiscount),
        nameof(Voucher.ExpiryDate)
    )]
    public async Task<IActionResult> Add(Voucher voucher)
    {
        if (await _context.Vouchers.AnyAsync(x => x.ID == voucher.ID))
        {
            return BadRequest("Tried to create a new voucher with an already used ID.");
        }

        if (ModelState.IsValid)
        {
            voucher.IssuerId = HttpContext.GetCurrentUserID()!.Value;
            bool codeExists = await _context.Vouchers.AnyAsync(v => v.Code == voucher.Code);
            if (codeExists)
            {
                ModelState.AddModelError(nameof(Voucher.Code), "Voucher code already exists. Please enter a different code.");
                return View(voucher);
            }

            _context.Update(voucher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        return View(voucher);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var voucher = await _context.Vouchers.Include(x => x.Orders).Include(x => x.Issuer).FirstOrDefaultAsync(x => x.ID == id);
        if (voucher == null) return NotFound();
        return View(voucher);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ModelStateInclude
    (
        nameof(Voucher.MinimumOrderPrice), 
        nameof(Voucher.DiscountValue),
        nameof(Voucher.IsPercentageDiscount),
        nameof(Voucher.ExpiryDate)
    )]
    public async Task<IActionResult> Edit(Voucher model)
    {
        if (ModelState.IsValid)
        {
            var existing = await _context.Vouchers.FirstOrDefaultAsync(x => x.ID == model.ID);
            if (existing is null)
            {
                return BadRequest("No voucher with such an ID exists.");
            }
            if (existing.Code != model.Code || existing.IssuerId == model.IssuerId)
            {
                return BadRequest("Bad identification data while trying to update voucher.");
            }

            existing.MinimumOrderPrice = model.MinimumOrderPrice;
            existing.DiscountValue = model.DiscountValue;
            existing.ExpiryDate = model.ExpiryDate;
            existing.IsPercentageDiscount = model.IsPercentageDiscount;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
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