using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           // routes.IgnoreRoute("Default/GetName");

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{EmpId}/{Ename}/{Salary}",
                defaults: new { controller = "default", action = "Index", EmpId = UrlParameter.Optional, Ename = UrlParameter.Optional, Salary = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default1",
                url: "Emp/Details",
                defaults: new { controller = "default", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{EmpId}",
                defaults: new { controller = "default", action = "Index", EmpId = UrlParameter.Optional }
            );
        }
    }
}
