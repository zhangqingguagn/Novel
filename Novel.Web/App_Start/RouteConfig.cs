using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Novel.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Novel-Index",
                "1-1",
                new { controller = "Novel", action = "Index" }
            );
            routes.MapRoute(
                "Novel-Details",
                "1-2/{novelId}",
                new { controller = "Novel", action = "Details" }
            );
            routes.MapRoute(
                "Novel-Edit",
                "1-3/{novelId}",
                new { controller = "Novel", action = "Edit" }
            );
            routes.MapRoute(
                "Chapter-Index",
                "2-1/{novelId}",
                new { controller = "Chapter", action = "Index" }
            );
            routes.MapRoute(
                "Chapter-Details",
                "2-2/{chapterId}",
                new { controller = "Chapter", action = "Details" }
            );
            routes.MapRoute(
                "Chapter-GetChapter",
                "2-3/{chapterId}",
                new { controller = "Chapter", action = "GetChapter" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Novel", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
