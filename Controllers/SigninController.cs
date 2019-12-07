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
            return View();
        }

        [HttpPost]
        public IActionResult Login(Credentials _credentials)
        {
            var user = _context.Users.FirstOrDefault(u=> (u.Credentials.Email == _credentials.Email));
            if (user == null)
            {
                ModelState.AddModelError("Email", "email not registered as account");
            } 
            else if (user.Credentials.Password != _credentials.Password)
            {
                ModelState.AddModelError("Password", "incorrect password");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Stats", user);
        }

    }
}