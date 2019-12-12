/*
 Principle Author: Richard Perocho
 This class is contained in the database and is the model for users
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Credentials Credentials { get; set; }
    }
}
