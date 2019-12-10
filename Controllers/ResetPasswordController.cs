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
                ViewBag.ErrorMessage = "This email is not registered with us.";
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
            return RedirectToAction("ResetPasswordForm");
        }

        public IActionResult ResetPasswordForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordForm(string _newPassword, string _confirmPassword)
        {
            if (_newPassword != _confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match";
                return View();
            }

            var credentials = _context.Credentials.Find(_credentials.Id);
            if (credentials == null)
            {
                return NotFound();
            }
            credentials.Password = _newPassword;

            await _context.SaveChangesAsync();
            return Content("Success");
        }
    }
}