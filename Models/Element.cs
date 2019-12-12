/*
 Principle Author: Adrian Gonzalez Madruga
 Element encompasses a line for the graph to handle
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinancialEnterpriseGenie.Models
{
    public class Element
    {
        public Element()
        {
            new List<DataPoint>();
        }
        public string type { get; set; }
        public String name { get; set; }
        public List<DataPoint> dataPoints { get; set; }
        public String xValueType { get; set; }
        public String yValueType { get; set; }
        public String xValueFormatString { get; set; }
        public String yValueFormatString { get; set; }
        public string dataToJson() { return JsonConvert.SerializeObject(dataPoints); }
    }
}
