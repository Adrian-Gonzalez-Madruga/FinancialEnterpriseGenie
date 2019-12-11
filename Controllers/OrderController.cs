using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Controllers
{

    public class OrderController : Controller
    {
        private GenieDatabase _context;

        public OrderController(GenieDatabase context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var distributor = await _context
                .Distributors
                .ToListAsync();
            var item = await _context
                .Items
                .ToListAsync();


            var itemDistributorList = new ItemDistributorList();

            itemDistributorList.DistributorId = distributor;

            itemDistributorList.ItemId = item;


            return View(itemDistributorList);
        }

        [HttpPost]
        public IActionResult Confirmation(int itemId, int distributorId, int quantity)
        {
            if (quantity <= 0)
            {
                quantity = 1;
            }

            var distributor = _context.Distributors.Find(distributorId);
            var item = _context.Items.Find(itemId);
            var user = _context.Users.Find(Convert.ToInt32(CookieUtil.GetCookie(Request, CookieUtil.USER_ID_KEY)));
            if (user == null)
            {
                return NotFound();
            }

            var receipt = new Receipt();
            receipt.Distributor = distributor;
            receipt.Item = item;
            receipt.Tax = Math.Round((0.13 * ((item.Price * quantity) + distributor.ShipPrice)), 2);
            receipt.ReceiveDate = DateTime.Now.AddDays(distributor.TimeToShip);
            receipt.Date = DateTime.Now;
            receipt.Quantity = quantity;
            receipt.Total = Math.Round((receipt.Tax + (item.Price * quantity) + distributor.ShipPrice), 2);
            receipt.User = user;

            _context.Receipts.Add(receipt);

            _context.SaveChanges();

            return View("Confirmation", receipt);
        }
        
    }
}