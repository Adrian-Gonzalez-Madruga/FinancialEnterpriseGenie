﻿/*
 Principle Author: Richard Perocho
 This class handles all type extensions
*/
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Extensions
{
    public static class MyExtensions
    {
        public static IActionResult NotLoggedIn(this Controller controller)
        {
            return controller.RedirectToAction("NotLoggedIn", "Signin");
        }

        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
