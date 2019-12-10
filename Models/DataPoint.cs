﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

//https://canvasjs.com/asp-net-mvc-charts/
namespace FinancialEnterpriseGenie.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(double x, double y)
        {
            this.x = x;
            this.Y = y;
        }

        [DataMember(Name = "x")]
        public double? x = null;

        [DataMember(Name = "y")]
        public double? Y = null;
    }
}
