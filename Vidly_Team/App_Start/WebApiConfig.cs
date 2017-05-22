using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vidly_Team
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // var settings=config.Formatters.JsonFormatter.SerializerSettings;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver= new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
