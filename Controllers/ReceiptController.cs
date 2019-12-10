using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> AllReceipts(int id)
        {
            //TODO: User needs a receipt id
            var receipt = await _context
                .Receipts
                //.Include(u => u.User)
                .ToListAsync();

            return View(receipt);
        }

    }
}