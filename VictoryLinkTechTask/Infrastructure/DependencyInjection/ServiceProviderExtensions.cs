using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VictoryLinkTechTask.Infrastructure.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> serviceTypes)
        {
            foreach (var type in serviceTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}