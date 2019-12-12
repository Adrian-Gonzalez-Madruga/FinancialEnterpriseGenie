/*
 Principle Author: Richard Perocho
 This class handles date types for razor view select
*/
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public static class DateSelect
    {
        public static SelectList Days {
            get {
                return new SelectList(Enumerable.Range(1, 31).ToArray());
            }
        }

        public static SelectList Months {
            get {
                var months = new Dictionary<int, string>()
                {
                    {1, "January"},
                    {2, "February"},
                    {3, "March"},
                    {4, "April"},
                    {5, "May"},
                    {6, "June"},
                    {7, "July"},
                    {8, "August"},
                    {9, "September"},
                    {10, "October"},
                    {11, "November"},
                    {12, "December"},
                };
                return new SelectList(months, "Key", "Value");
            }
        }

        public static SelectList Years {
            get {
                return new SelectList(Enumerable.Range(1900, (DateTime.Now.Year - 1900 + 1)).ToArray().Reverse());
            }
        }
    }
}
