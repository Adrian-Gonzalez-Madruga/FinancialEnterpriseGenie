/*
 Principle Author: Adrian Gonzalez Madruga
 Sale in Database
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public Item Item { get; set; }
        public int Units { get; set; }
        public DateTime Date { get; set; }
    }
}
