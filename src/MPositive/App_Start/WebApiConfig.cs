using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MPositive
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //TODO move this out into area registration
            config.Routes.MapHttpRoute(
                name:"Update Products",
                routeTemplate:"api/account/{accountId}/updateProducts",
                defaults:new { action = "Post", Controller = "UpdateProducts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name:"New Products",
                routeTemplate:"api/account/{accountId}/newProducts",
                defaults:new { action = "Post", Controller = "NewProducts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Get Products",
                routeTemplate: "api/account/{accountId}/Products",
                defaults: new { action = "GET", Controller = "Products", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
