using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Todos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Routes.MapHttpRoute(
                name: "GetTodos",
                routeTemplate: "api/todos",
                defaults: new { controller = "Todos" }
            );
            //config.Routes.MapHttpRoute(
            //    name: "GetTodo",
            //    routeTemplate: "api/todos/{id}",
            //    defaults: new { controller = "Todos", action = "Get", id = RouteParameter.Optional }
            //);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}