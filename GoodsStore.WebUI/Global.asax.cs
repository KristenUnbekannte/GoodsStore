using GoodsStore.BusinessLogic;
using GoodsStore.BusinessLogic.Services;
using GoodsStore.WebUI.Infrastructure.Binders;
using GoodsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GoodsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new GoodsDbInitializer());
            //Database.SetInitializer(new AppDbInitializer());
            AutoMapper.Mapper.Initialize(cfg=>cfg.AddProfile<BLLMappingProfile>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
