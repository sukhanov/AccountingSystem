using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace AccountingSystem.Web
{
    public class Global : HttpApplication
    {
        private const string ROOT_DOCUMENT = "/";

        private void Application_Start(object sender, EventArgs e)
        {
            AutomapperConfig.Init();
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.Remove(
                GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var url = Request.Url.LocalPath;
            var pattern = "api";

            var match = Regex.Match(url, pattern);

            if (!match.Success)
            {
                if (!System.IO.File.Exists(Context.Server.MapPath(url)))
                {
                    Context.RewritePath(ROOT_DOCUMENT);
                }
            }
        }
    }
}