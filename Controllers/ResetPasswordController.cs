using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class ResetPasswordController : Controller
    {
        private static Credentials _credentials;
        private GenieDatabase _context;

        public ResetPasswordController(GenieDatabase context)
        {
            _context = context;
        }

        public IActionResult CheckEmailForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckEmailForm(string _email)
        {
            var credentials = _context.Credentials.FirstOrDefault(c => c.Email == _email);

            if (credentials == null)
            {
                ModelState.AddModelError("Email", "This email is not registered with us.");
                return View();
            }

            _credentials = credentials;
            return RedirectToAction("SecurityQuestionForm");
        }

        public IActionResult SecurityQuestionForm()
        {
            return View((object)_credentials.SecurityQuestion);
        }

        [HttpPost]
        public IActionResult SecurityQuestionForm(string _answer)
        {
            if (_answer != _credentials.SecurityAnswer)
            {
                ViewBag.ErrorMessage = "Answers did not match";
                return View((object)_credentials.SecurityQuestion);
            }
            return View();
        }
    }
}