using System;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var db = new DBContext();
            int CountOfUser = db.Users.Count();
            if (CountOfUser == 0) LoginOps.CreateFirstUser();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            if (exception != null)
            {
                var Messege = "<hr/> Mesaj: <br/>" + exception.Message + "<br/>";
                var StackTrace = "<hr/> StackTrace: <br/>" + exception.StackTrace + "<br/>";
                var InnerException = "<hr/> InnerException: <br/>" + exception.InnerException + "<br/>";
                var Source = "<hr/> Source: <br/>" + exception.Source + "<br/>";
                var Data = "<hr/> Data: <br/>" + exception.Data + "<br/>";
                var HelpLink = "<hr/> HelpLink: <br/>" + exception.HelpLink + "<br/>";
                var HResult = "<hr/> HResult: <br/>" + exception.HResult + "<br/>";
                var TargetSite = "<hr/> TargetSite: <br/>" + exception.TargetSite + "<br/>";
                var Text = Messege + StackTrace + InnerException + Source + Data + HelpLink + HResult + TargetSite;
                var log = new Logger(new ErrorLogger());
                log.LogEkle(Text);
            }
        }
    }
}