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
        private GenieDatabase _context;

        public ResetPasswordController(GenieDatabase context) // TODO: temporarily save credentials id to cookie, then delete when finished.
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

            return RedirectToAction("SecurityQuestionForm", new { _id = credentials.Id });
        }

        public IActionResult SecurityQuestionForm(int _id)
        {
            var credentials = _context.Credentials.Find(_id);
            if (credentials == null)
            {
                return Content("something went wrong");
            }

            ViewBag.Id = _id;
            ViewBag.SecurityQuestion = credentials.SecurityQuestion;
            return View();
        }

        [HttpPost]
        public IActionResult SecurityQuestionForm(string _answer, int _id)
        {
            var credentials = _context.Credentials.Find(_id);
            if (credentials == null)
            {
                return Content("something went wrong");
            }
            if (_answer == null || _answer.Trim() == "")
            {
                ViewBag.ErrorMessage = "Enter an answer";
            }
            else if (_answer != credentials.SecurityAnswer)
            {
                ViewBag.ErrorMessage = "Answers did not match";
            }

            if (ViewBag.ErrorMessage != null)
            {
                ViewBag.Id = _id;
                ViewBag.SecurityQuestion = credentials.SecurityQuestion;
                return View();
            }
            return RedirectToAction("ResetPasswordForm", new { id = _id});
        }

        public IActionResult ResetPasswordForm(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordForm(string _newPassword, string _confirmPassword, int _id)
        {
            if (_newPassword == null || _newPassword.Trim() == "")
            {
                ViewBag.ErrorMessage = "Password is empty";
            }
            if (_newPassword != _confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match";
            }
            if (ViewBag.ErrorMessage != null)
            {
                ViewBag.Id = _id;
                return View();
            }
            var credentials = _context.Credentials.Find(_id);
            if (credentials == null)
            {
                return NotFound();
            }
            credentials.Password = _newPassword;

            await _context.SaveChangesAsync();
            return RedirectToAction("LoginForm", "Signin");
        }
    }
}