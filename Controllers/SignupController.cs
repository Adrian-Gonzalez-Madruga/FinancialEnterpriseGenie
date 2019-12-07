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
        public IActionResult SignupForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignupForm(SignupModel _signupModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            return Content("success");
        }

    }
}