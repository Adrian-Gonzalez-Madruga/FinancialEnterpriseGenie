using System;
using System.Collections.Generic;
using System.Linq;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult DefaultGraph()
        {
            
            return RedirectToAction("Index", "Stats"); //, new RouteValueDictionary(graph)
        }
        public IActionResult Index()
        {
            Graph graph = new Graph() { name = "Item Sales By Week", shared = "true", xTitle = "Date", xValueFormatString = "DD MMM YYYY", yTitle = "Number of Units Sold" };
            List<Item> items = _context.Items.ToList();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < items.Count; i++)
            {
                List<Sale> sales = _context.Sales.Where(s => s.Item == items[i]).OrderBy(s => s.Date).ToList();
                List<DataPoint> dataPoints = new List<DataPoint>();
                for (int j = 0; j < sales.Count; j++)
                {
                    dataPoints.Add(new DataPoint((sales[j].Date - epoch).TotalSeconds*1000, sales[j].Units));
                }
                graph.elements.Add(new Element() { type = "spline", name = items[i].ProductName, dataPoints = dataPoints, xValueType = "dateTime", xValueFormatString = "DD MMM" });
            }
            ViewBag.Graph = graph;
            return View();
        }

        public IActionResult Create()
        {
            int[] startItemSale = {45, 30, 9, 90, 36, 42, 30, 24, 51, 81};
            double[] weekFluctuation = {0.60, 0.70, 0.70, 0.85, 0.95, 1.25, 1.4, 1, 1.05, 1, 1.25, 1.2, 1.1, 0.9, 0.9, 0.8, 0.68, 0.95, 1.05, 1.05, 1.1, 1.1, 1, 1, 1, 1, 1.15, 1.1, 1.15, 1.2, 1.2, 1.25, 1.3, 1.3, 1.25, 1.3, 1.45, 1.2, 1, 1, 0.8, 1, 0.8, 0.65, 0.55, 0.5, 2, 2, 1, 1.25, 1.7, 1.9};
            int numOfYears = 2;
            int barSize = 12;
            List<int> sales = new List<int>();
            List<Item> items = _context.Items.ToList();
            double rating;
            List<int> entryCounter = new List<int>();
            for (int i = 0; i < items.Count; i++)
            {
                DateTime date = new DateTime(2013, 01, 01);
                Item item = items[i];
                int counter = 0;
                int numPreviousSales = 4;
                Queue<int> pastSales = new Queue<int>();
                pastSales.Enqueue(startItemSale[i]);
                for (int j = 0; j < (numOfYears * weekFluctuation.Length); j++)
                {
                    double mean = sales.Count > 0 ? sales.Average() : startItemSale[i];
                    double variance = (weekFluctuation[(j % weekFluctuation.Length)] * ((rating = item.Rating) > 3 ? 1 + ((rating - 3)/2) : ((rating - 1)/2)));
                    bool isPos = (variance >= 1);
                    int min = Convert.ToInt32(-1*((barSize / 2) * (isPos ? (variance - 1) :(variance + 1))));
                    int max = Convert.ToInt32(variance * (barSize / 2));
                    int unitsSold = Convert.ToInt32(Math.Round(pastSales.Average() + (random.Next(min, max))));
                    unitsSold = unitsSold < 0 ? 0 : unitsSold;
                    if (pastSales.Count >= numPreviousSales)
                    {
                        pastSales.Dequeue();
                    }
                    pastSales.Enqueue(unitsSold);
                    sales.Append(unitsSold);
                    Sale sale = new Sale() {Item = item, Units = unitsSold, Date = date};
                    _context.Sales.Add(sale);
                    date = date.AddDays(7);
                    counter++;
                }
                entryCounter.Append(counter);
            } 
            _context.SaveChanges();
            String counterString = "";
            for (int i = 0; i < entryCounter.Count; i++)
            {
                counterString += "\n" + i + ". " + entryCounter[i];
            }
            return Content("ya ho" + counterString);
        }

        public IActionResult Delete()
        {
            _context.Sales.RemoveRange(_context.Sales.ToList());
            _context.SaveChangesAsync();
            return Content("Deleted Sales");
        }
    }
}