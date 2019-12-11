using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using FinancialEnterpriseGenie.Extensions;

namespace FinancialEnterpriseGenie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (CookieUtil.UserLoggedIn(Request))
            {
                return this.NotLoggedIn();
            }

            return View();
        }
    }
}