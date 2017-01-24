﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NNShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Search",
               url: "tim-kiem.html",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
               namespaces: new string[] { "NNShop.Web.Controller" }
           );

            routes.MapRoute(
               name: "Login",
               url: "dang-ki",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "NNShop.Web.Controller" }
           );

            routes.MapRoute(
               name: "Register",
               url: "dang-nhap",
               defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               namespaces: new string[] { "NNShop.Web.Controller" }
           );

            routes.MapRoute(
               name: "Page",
               url: "trang/{alias}.html",
               defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
               namespaces: new string[] { "NNShop.Web.Controller" }
            );

            routes.MapRoute(
                name: "Product Category",
                url: "{alias}.pc-{id}.html",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "NNShop.Web.Controller" }
            );

            routes.MapRoute(
                name: "Product",
                url: "{alias}.p-{id}.html",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "NNShop.Web.Controller" }
            );

            routes.MapRoute(
                name: "TagList",
                url: "tag/{tagId}.html",
                defaults: new { controller = "Product", action = "ListByTag", tagId = UrlParameter.Optional },
                namespaces: new string[] { "NNShop.Web.Controller" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NNShop.Web.Controller" }
            );
        }
    }
}
