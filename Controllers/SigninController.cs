using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class SigninController : Controller
    {
        private GenieDatabase _context;
        public SigninController(GenieDatabase context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            var user = new User() { FirstName = "Connor", LastName = "Clarckson" };
            return RedirectToAction("Index", "Stats", user);
        }

        [HttpPost]
        public IActionResult Login(Credentials _credentials)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Stats");
        }

    }
}