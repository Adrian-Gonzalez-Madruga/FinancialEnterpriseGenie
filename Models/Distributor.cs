﻿/*
 Principle Author: Connor Clarkson
 This is the distributor model that gets/sets all the data for distributors
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string ShippingMethod { get; set; }
        public int TimeToShip { get; set; }
        public double ShipPrice { get; set; }
    }
}
