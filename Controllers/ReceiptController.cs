﻿/*
 Principle Author: Connor Clarkson
 This controller manipulates data surrounding the receipt database
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Extensions;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Controllers
{
    public class ReceiptController : Controller
    {
        private GenieDatabase _context;

        public ReceiptController(GenieDatabase context)
        {
            _context = context;
        }

        public IActionResult UserReceipts()
        {
            if (CookieUtil.GetCookie(Request, CookieUtil.USER_ID_KEY) == null)
            {
                return this.NotLoggedIn();
            }

            return View(_context.Receipts
                .Include(r => r.Item)
                .Where(r => r.User.Id == Convert.ToInt32(CookieUtil.GetCookie(Request, CookieUtil.USER_ID_KEY))).ToList());
        }

        public async Task<IActionResult> AllReceipts()
        {
            var receipt = await _context
                .Receipts
                .Include(u => u.User)
                .Include(i => i.Item)
                .ToListAsync();

            return View(receipt);
        }

        public IActionResult Details(int id)
        {
            var receipt = _context.Receipts
                .Include(r => r.Item)
                .Include(r => r.Distributor)
                .FirstOrDefault(r => r.Id == id);
            if (receipt == null)
            {
                return Content("could not find receipt");
            }
            return View(receipt);
        }
    }
}