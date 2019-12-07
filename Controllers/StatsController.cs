using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index(User _user)
        {
            return View(_user);
        }
    }
}