using HoaLacLaptopShop.Areas.Administration.ViewModels;
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

    public async Task<IActionResult> Index(VoucherIndexArgs args)
    {
        var vouchers = _context.Vouchers
            .Include(x => x.Issuer)
            .OrderByDescending(x => x.ID)
            .AsQueryable();

        if (ModelState.IsValid)
        {
            if (!string.IsNullOrWhiteSpace(args.Search))
            {
                vouchers = vouchers.Where
                (
                    x => x.Code.ToLower().Contains(args.Search.ToLower())
                        || x.Issuer.Name.ToLower().Contains(args.Search.ToLower())
                );
            }
            if (args.MinimumOrderPrice.HasValue)
            {
                vouchers = vouchers.Where(x => x.MinimumOrderPrice >= args.MinimumOrderPrice.Value);
            }
            if (!args.ShowExpired)
            {
                vouchers = vouchers.Where(x => x.ExpiryDate >= DateTime.Now);
            }
        }

        const int VOUCHERS_PER_PAGE = 20;
        var pages = (int)Math.Ceiling((await vouchers.CountAsync()) / (float)VOUCHERS_PER_PAGE);
        if (!ModelState.IsValid) args.Page = 1;
        vouchers = vouchers.Skip((args.Page - 1) * VOUCHERS_PER_PAGE).Take(VOUCHERS_PER_PAGE);

        var vm = new VoucherIndexViewModel()
        {
            TotalPages = pages,
            Vouchers = await vouchers.ToListAsync()
        };
        vm.FillFromOther(args);
        return View(vm);
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
            this.AddMessage("Successfully added voucher.");
            return RedirectToAction(nameof(Index));
        }
       
        return View(voucher);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var voucher = await _context.Vouchers.Include(x => x.Orders).Include(x => x.Issuer).FirstOrDefaultAsync(x => x.ID == id);
        if (voucher == null)
        {
            this.AddError("The requested voucher could not be found.");
            return NotFound();
        }
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
            if (existing.Code != model.Code || existing.IssuerId != model.IssuerId)
            {
                return BadRequest("Bad identification data while trying to update voucher.");
            }

            existing.MinimumOrderPrice = model.MinimumOrderPrice;
            existing.DiscountValue = model.DiscountValue;
            existing.ExpiryDate = model.ExpiryDate;
            existing.IsPercentageDiscount = model.IsPercentageDiscount;
            await _context.SaveChangesAsync();
            this.AddMessage("Successfully edited voucher.");
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var voucher = await _context.Vouchers.FindAsync(id);
        if (voucher is null)
        {
            this.AddError("The requested voucher could not be found.");
            return NotFound();
        }

        _context.Vouchers.Remove(voucher);
        await _context.SaveChangesAsync();
        this.AddMessage("Successfully deleted voucher.");
        return RedirectToAction(nameof(Index));
    }
}