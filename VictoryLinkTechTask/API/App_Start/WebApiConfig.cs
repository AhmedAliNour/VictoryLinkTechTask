using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using VictoryLinkTechTask.Application.Services.Concrets;
using VictoryLinkTechTask.Application.Services.Interfaces;
using VictoryLinkTechTask.Infrastructure.DependencyInjection;
using VictoryLinkTechTask.Infrastructure.Persistance;

namespace VictoryLinkTechTask.API.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var services = new ServiceCollection();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<AppDbContext>();


            services.AddControllersAsServices(typeof(WebApiConfig).Assembly.GetTypes().Where(e => e.BaseType == typeof(ApiController)));
            var resolver = new DependencyResolver(services.BuildServiceProvider());
            config.DependencyResolver = resolver;
        }
    }
}
