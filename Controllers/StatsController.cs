using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Controllers
{
    public class StatsController : Controller
    {
        private GenieDatabase _context;
        private Random random = new Random((int)DateTime.Now.Ticks);
        public StatsController(GenieDatabase context)
        {
            _context = context;
        }
        public IActionResult Index(User _user)
        {
            return View(_user);
        }

        public async Task<IActionResult> Create()
        {
            double[] startItemSale = {15, 10, 3, 30, 12, 14, 10, 8, 17, 27};
            double[] weekFluctuation = {0.60, 0.70, 0.70, 0.85, 0.95, 1.25, 1.4, 1, 1.05, 1, 1.25, 1.2, 1.1, 0.9, 0.9, 0.8, 0.68, 0.95, 1.05, 1.05, 1.1, 1.1, 1, 1, 1, 1, 1.15, 1.1, 1.15, 1.2, 1.2, 1.25, 1.3, 1.3, 1.25, 1.3, 1.45, 1.2, 1, 1, 0.8, 1, 0.8, 0.65, 0.55, 0.5, 2, 2, 1, 1.25, 1.7, 1.9};
            int numOfYears = 5;
            int barSize = 14;
            List<int> sales = new List<int>();
            List<Item> items = await _context.Items.ToListAsync();
            double rating;
            List<int> entryCounter = new List<int>();
            for (int i = 0; i < startItemSale.Length; i++)
            {
                DateTime date = new DateTime(2020, 01, 01);
                Item item = items[i];
                int counter = 0;
                for (int j = 0; j < (numOfYears * weekFluctuation.Length); j++)
                {
                    double mean = sales.Count > 0 ? sales.Average() : startItemSale[i];
                    double variance = 4 * weekFluctuation[(j % weekFluctuation.Length)] * ((rating = item.Rating) > 3 ? 1 + ((rating - 3)/2) : ((rating - 1)/2));
                    int min = Convert.ToInt32(variance - (barSize / 2));
                    int max = Convert.ToInt32(variance + (barSize / 2));
                    int unitsSold = Convert.ToInt32(Math.Round(mean + (random.Next(min, max))));
                    unitsSold = unitsSold < 0 ? 0 : unitsSold;
                    sales.Append(unitsSold);
                    Sale sale = new Sale() {Item = item, Units = unitsSold, Date = date};
                    _context.Sales.Add(sale);
                    date = date.AddDays(7);
                    counter++;
                }
                entryCounter.Append(counter);
            }
            await _context.SaveChangesAsync();
            String counterString = "";
            for (int i = 0; i < entryCounter.Count; i++)
            {
                counterString += "\n" + i + ". " + entryCounter[i];
            }
            return Content("ya ho" + counterString);
        }
    }
}