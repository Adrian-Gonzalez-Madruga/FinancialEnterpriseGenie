﻿/*
 Principle Author: Connor Clarkson
 This is the receipt model that gets/sets all the data for receipts
*/
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
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReceiveDate { get; set; }
        public Distributor Distributor { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
