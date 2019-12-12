/*
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
        /*
         The UserReceipts method was created by Richard Perocho
        */
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
        /*
         The AllReceipts Method was created by Connor Clarkson
         This method includes the users and items associated with each receipt and passes the receipt variable to the AllReceipts view
        */
        public async Task<IActionResult> AllReceipts()
        {
            var receipt = await _context
                .Receipts
                .Include(u => u.User)
                .Include(i => i.Item)
                .ToListAsync();

            return View(receipt);
        }
        /*
         The Details method was created by Richard Perocho
        */
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