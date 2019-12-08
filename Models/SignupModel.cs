using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "confirmation email missing")]
        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage = "Please enter desired password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "confirmation password missing")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please select a security question")]
        public string SecurityQuestoin { get; set; }
        [Required(ErrorMessage = "Please enter the answer to the security question")]
        public string SecurityAnswer { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your credit card number")]
        [RegularExpression(@"^\d{4}-\d{4}-\d{4}$", ErrorMessage = "please follow the format: XXXX-XXXX-XXXX")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DateOfBirth { get; set; }

        public bool EmailsMatch()
        {
            return (Email == ConfirmEmail);
        }

        public bool PasswordsMatch()
        {
            return (Password == ConfirmPassword);
        }
    }
}
