/*
 Principle Author: Adrian Gonzalez Madruga
 This is the Graph to be implemented in Stats/Index containing elements (lines)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    
    public class Graph
    {
        public List<Element> elements;
        public Graph()
        {
            elements = new List<Element>();
        }
        public String name { get; set; }
        public String xValueFormatString { get; set; }
        public String xPrefix { get; set; }
        public object xTitle { get; set; }
        public String yValueFormatString { get; set; }
        public String yPrefix { get; set; }
        public object yTitle { get; set; }
        public String shared { get; set; } = "true";
    }
}
