using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (CookieUtil.GetCookie(Request, CookieUtil.USER_ID_KEY) == null)
            {
                return RedirectToAction("NotLoggedIn", "Signin");
            }
            return View();
        }
    }
}