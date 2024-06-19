<<<<<<< Updated upstream
﻿using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Models;

using System;
using System.Collections.Generic;
using System.Linq;


namespace HoaLacLapTopShop.Controllers
{
    public class VoucherController : Controller
    {
        // Simulating a database with an in-memory list
        private static List<Voucher> vouchers = new List<Voucher>();

        // GET: Voucher
        public IActionResult Index()
        {
            return View(vouchers);
        }

        // GET: Voucher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voucher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                voucher.ID = vouchers.Count + 1;
                vouchers.Add(voucher);
                return RedirectToAction(nameof(Index));
            }
            return View(voucher);
        }

        // GET: Voucher/Update/5
        public IActionResult Update(int id)
        {
            var voucher = vouchers.FirstOrDefault(v => v.ID == id);
            if (voucher == null)
            {
                return NotFound();
            }
            return View(voucher);
        }

        // POST: Voucher/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Updatea(int id, Voucher updatedVoucher)
        {
            if (ModelState.IsValid)
            {
                var voucher = vouchers.FirstOrDefault(v => v.ID == id);
                if (voucher != null)
                {
                    voucher.MinimumOrderPrice = updatedVoucher.MinimumOrderPrice;
                    voucher.DiscountValue = updatedVoucher.DiscountValue;
                    voucher.IsPercentageDiscount = updatedVoucher.IsPercentageDiscount;
                    voucher.ExpiryDate = updatedVoucher.ExpiryDate;
                    voucher.IssuerId = updatedVoucher.IssuerId;
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(updatedVoucher);
        }

        // GET: Voucher/Delete/5
        public IActionResult Delete(int id)
        {
            var voucher = vouchers.FirstOrDefault(v => v.ID == id);
            if (voucher == null)
            {
                return NotFound();
            }
            return View(voucher);
        }

        // POST: Voucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var voucher = vouchers.FirstOrDefault(v => v.ID == id);
            if (voucher != null)
            {
                vouchers.Remove(voucher);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
=======
﻿using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class VoucherController : Controller
{
    private readonly HoaLacLaptopShopContext _context;

    public VoucherController(HoaLacLaptopShopContext context)
    {
        _context = context;
    }

    // GET: Voucher/Index
    public async Task<IActionResult> Index(string sortOrder)
    {
        ViewData["CodeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "code_desc" : ""; 
        var vouchers = from v in _context.Vouchers
                       select v;

        switch (sortOrder)
        {
            case "code_desc":
                vouchers = vouchers.OrderByDescending(v => v.Code);
                break;
            default:
                vouchers = vouchers.OrderBy(v => v.Code);
                break;
        }
        return View(await _context.Vouchers.ToListAsync());
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
    public async Task<IActionResult> Create([Bind("Code,MinimumOrderPrice,DiscountValue,IsPercentageDiscount,ExpiryDate,IssuerId")] Voucher voucher)
    {
        if (ModelState.IsValid)
        {
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
        ViewData["CodeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "code_desc" : ""; 

        var vouchers = from v in _context.Vouchers
                       select v;

        if (!String.IsNullOrEmpty(query))
        {
            vouchers = vouchers.Where(s => s.Code.Contains(query) || s.IssuerId.ToString().Contains(query));
        }

        switch (sortOrder)
        {
            case "code_desc":
                vouchers = vouchers.OrderByDescending(v => v.Code);
                break;
            default:
                vouchers = vouchers.OrderBy(v => v.Code);
                break;
        }

        return View("Index", await vouchers.ToListAsync());
>>>>>>> Stashed changes
    }
}