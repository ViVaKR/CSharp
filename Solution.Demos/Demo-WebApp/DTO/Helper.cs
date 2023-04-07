using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Demo_WebApp.DTO
{
    public class Helper
    {
        private static string GetUserIP()
        {
            HttpContext currentContext = System.Web.HttpContext.Current;
            string ipaddress;
            ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            return ipaddress;
        }
    }
}
