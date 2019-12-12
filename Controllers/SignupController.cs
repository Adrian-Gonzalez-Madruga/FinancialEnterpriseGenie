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
        private GenieDatabase _conext;
        public SignupController(GenieDatabase context)
        {
            _conext = context;
        }

        public IActionResult SignupForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignupForm(SignupModel _signupModel)
        {
            if (_conext.Credentials.FirstOrDefault(c => c.Email == _signupModel.Email) != null)
            {
                ModelState.AddModelError("Email", "This email is already has a registered account");
            }
            if (!_signupModel.PasswordsMatch())
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do no match");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var credentials = new Credentials()
            {
                Email = _signupModel.Email,
                Password = _signupModel.Password,
                SecurityQuestion = _signupModel.SecurityQuestoin,
                SecurityAnswer = _signupModel.SecurityAnswer
            };

            var user = new User()
            {
                FirstName = _signupModel.FirstName,
                LastName = _signupModel.LastName,
                Address = _signupModel.Address,
                CreditCardNumber = _signupModel.CreditCardNumber,
                DateOfBirth = _signupModel.DateOfBirth,
                Credentials = credentials
            };

            _conext.Users.Add(user);
            _conext.Credentials.Add(user.Credentials);
            await _conext.SaveChangesAsync();

            return RedirectToAction("LoginForm", "Signin");
        }

    }
}