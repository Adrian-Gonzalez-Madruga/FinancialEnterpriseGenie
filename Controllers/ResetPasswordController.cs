/*
 Principle Author: Richard Perocho
 This controller manages user resetting passwrd
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Extensions;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialEnterpriseGenie.Controllers
{
    public class ResetPasswordController : Controller
    {
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

            CookieUtil.AddCookie(Response, CookieUtil.CREDENTIALS_ID_KEY, credentials.Id.ToString());
            return RedirectToAction("SecurityQuestionForm");
        }

        public IActionResult SecurityQuestionForm()
        {
            var credentials = _context.Credentials.Find(CookieUtil.GetCookie(Request, CookieUtil.CREDENTIALS_ID_KEY).ToInt());
            if (credentials == null)
            {
                return Content("something went wrong");
            }
            ViewBag.SecurityQuestion = credentials.SecurityQuestion;
            return View();
        }

        [HttpPost]
        public IActionResult SecurityQuestionForm(string _answer)
        {
            var credentials = _context.Credentials.Find(CookieUtil.GetCookie(Request, CookieUtil.CREDENTIALS_ID_KEY).ToInt());
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
                ViewBag.SecurityQuestion = credentials.SecurityQuestion;
                return View();
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
                return View();
            }
            var credentials = _context.Credentials.Find(CookieUtil.GetCookie(Request, CookieUtil.CREDENTIALS_ID_KEY).ToInt());
            if (credentials == null)
            {
                return NotFound();
            }
            credentials.Password = _newPassword;

            await _context.SaveChangesAsync();
            CookieUtil.DeleteCookie(Response, CookieUtil.CREDENTIALS_ID_KEY);
            return RedirectToAction("LoginForm", "Signin");
        }
    }
}