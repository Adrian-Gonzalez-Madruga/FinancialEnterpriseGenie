using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Controllers
{
    public class SigninController : Controller
    {
        private GenieDatabase _context;
        public SigninController(GenieDatabase context)
        {
            _context = context;
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginForm(Credentials _credentials)
        {
            var user = _context.Users.Include(u => u.Credentials).FirstOrDefault(u=> (u.Credentials.Email == _credentials.Email));

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

            CookieUtil.AddCookie(Response, CookieUtil.USER_ID_KEY, user.Id.ToString());
            return RedirectToAction("Index", "Stats");
        }

        public IActionResult Logout()
        {
            CookieUtil.ClearAllCookies(Request, Response);
            return RedirectToAction("LoginForm");
        }
    }
}