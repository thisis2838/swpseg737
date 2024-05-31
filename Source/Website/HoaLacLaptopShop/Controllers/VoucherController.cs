using Microsoft.AspNetCore.Mvc;
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
    }
}