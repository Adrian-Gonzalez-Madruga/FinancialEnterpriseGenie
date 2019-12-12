/*
 Principle Author: Richard Perocho
 This class is contained in the database and is the model for user credentials
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public static string[] SecurityQuestions = new string[]
        {
            "What is your favourite videogame?",
            "What was your first pet's name? ",
            "What is your mother's maiden name?",
            "Where is your hometown?",
            "Where did you go to High school / College?",
            "What was they first company you worked for?"
        };
    }
}
