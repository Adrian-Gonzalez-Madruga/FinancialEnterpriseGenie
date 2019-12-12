/*
 Principle Author: Adrian Gonzalez Madruga
 Item in Database 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class Item
    {
        public int Id { get; set; }
        public String ProductName { get; set; }
        public double Price { get; set; }
        public double MRP { get; set; }
        public double Rating { get; set; }
        public String Color { get; set; }
    }
}
