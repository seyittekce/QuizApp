﻿using System.Web.Mvc;
using System.Web.Routing;

namespace QuizApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
            routes.MapRoute(
                "Exam Page",
                "{controller}/{action}/{questions}/{Class}/{library}",
                new
                {
                    controller = "Students", action = "Exam", Questions = UrlParameter.Optional,
                    Class = UrlParameter.Optional, library = UrlParameter.Optional
                }
            );
        }
    }
}