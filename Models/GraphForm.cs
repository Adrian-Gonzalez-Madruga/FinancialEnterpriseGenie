using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class GraphForm
    {
        public bool[] ChosenItems { get; set; } = new bool[1000];
        [Required(ErrorMessage = "A Graph Type Must Be Selected")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Number of Decimal Weeks Per DataPoint Mandatory")]
        public decimal? NumWeeks { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Starting Date Required")]
        public DateTime? MinDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ending Date Required")]
        public DateTime? MaxDate { get; set; }
    }
}
