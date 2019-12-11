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

        public static void SetUserIdCookie(HttpResponse response, string id)
        {
            response.Cookies.Append(USER_ID_KEY, id);
        }
    }
}
