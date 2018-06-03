using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoodsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Goods",
                    action = "GoodsCards",
                    category = UrlParameter.Optional,
                    page = 1
                }
            );
            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { controller = "Goods", action = "List", category = UrlParameter.Optional },
            //    constraints: new { page = @"\d+" }
            //);

            //routes.MapRoute(null,
            //    "{category}",
            //    new { controller = "Goods", action = "List", page = 1 }
            //);

            //routes.MapRoute(null,
            //    "{category}/Page{page}",
            //    new { controller = "Goods", action = "List" },
            //    new { page = @"\d+" }
            //);

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
