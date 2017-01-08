using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AccountingSystem.Web.Helpers
{
    public class FilterIPAttribute:AuthorizeAttribute
    {
        public string IPsConfig { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            var userIpAddress = ((HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request.UserHostName;

            try
            {
                return CheckAllowedIPs(userIpAddress);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }

            return true; 
        }

        private bool CheckAllowedIPs(string userIp)
        {
            if (string.IsNullOrEmpty(IPsConfig)) return false;
            var ips = ConfigurationManager.AppSettings[IPsConfig];
            if (string.IsNullOrEmpty(ips)) return false;
            var array = SplitIPs(ips);
            return array.Contains(userIp);
        }

        private static IEnumerable<string> SplitIPs(string ips)
        {
            return ips.Split(',');
        }
    }
}