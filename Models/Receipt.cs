using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        [Required(ErrorMessage = "Please Enter a Quantity Over 0")]
        [RegularExpression(@"^[1-9][0-9]*$")]
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReceiveDate { get; set; }
        public Distributor Distributor { get; set; }
        public IEnumerable<User> User { get; set; }
        public Item Item { get; set; }
    }
}
