/*
 Principle Author: Adrian Gonzalez Madruga
 Form taken from Stats/Index to allow variable graph controls
*/
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
        public DateTime MinDate {
            get {
                return new DateTime(MinYear, MinMonth, MinDay);
            }
        }
        public DateTime MaxDate {
            get {
                return new DateTime(MaxYear, MaxMonth, MaxDay);
            }
        }

        public int MinDay { get; set; }
        public int MinMonth { get; set; }
        public int MinYear { get; set; }
        public int MaxDay { get; set; }
        public int MaxMonth { get; set; }
        public int MaxYear { get; set; }
    }
}
