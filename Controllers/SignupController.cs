using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Credentials _credentials, string _confirmPassword)
        {
            if (_credentials.Password != _confirmPassword)
            {
                ModelState.AddModelError("Password", "Passowrds do not match");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            return Content("success");
        }
    }
}