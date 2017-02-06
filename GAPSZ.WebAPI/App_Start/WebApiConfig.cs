using GAPSZ.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GAPSZ.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Exception handling
            config.Filters.Add(new WebAPIErrorsHandlerAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "services/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "API Action",
                routeTemplate: "services/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );
        }
    }
}
