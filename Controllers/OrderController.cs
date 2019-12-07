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
        /*  public IActionResult Index()
          {


              return View();
          }*/

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
            /*
           // Request.Form.TryGetValue(distributor, name);

            var receipt = new Receipt();

            receipt.Distributor = distributor;
            receipt.Item = item;
            receipt.Tax = 0.13 * (item.Price + distributor.ShipPrice);
            receipt.ReceiveDate = DateTime.Now;
            receipt.Date = DateTime.Now;
            receipt.User = null;
            receipt.Quantity = quantity;
            receipt.Total = receipt.Tax + item.Price + distributor.ShipPrice;
            */
            //.Distributor = receipt.Distributor;

            //receipt = receipt;

            var distributor = _context.Distributors.Find(distributorId);
            var item = _context.Items.Find(itemId);

            var receipt = new Receipt();
            receipt.Distributor = distributor;
            receipt.Item = item;
            receipt.Tax = 0.13 * ((item.Price * quantity) + distributor.ShipPrice);
            receipt.ReceiveDate = DateTime.Now;
            receipt.Date = DateTime.Now;
            receipt.Quantity = quantity;
            receipt.Total = receipt.Tax + (item.Price * quantity) + distributor.ShipPrice;
            


            _context.Receipts.Add(receipt);

            _context.SaveChanges();

            return View("Confirmation", receipt);
        }
        
    }
}