using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public static class CookieUtil
    {
        public const string USER_ID_KEY = "UserId";

        public static void ClearAllCookies(HttpRequest request, HttpResponse response)
        {
            foreach (var cookie in request.Cookies.Keys)
            {
                response.Cookies.Delete(cookie);
            }
        }

        public static void SetCookie(HttpResponse response, string key, string val)
        {
            response.Cookies.Append(key, val);
        }

        public static string GetCookie(HttpRequest request, string key)
        {
            return request.Cookies[key];
        }
    }
}
