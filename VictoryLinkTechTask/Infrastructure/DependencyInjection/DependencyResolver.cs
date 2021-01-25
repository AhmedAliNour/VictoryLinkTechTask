using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace VictoryLinkTechTask.Infrastructure.DependencyInjection
{
    public class DependencyResolver : System.Web.Mvc.IDependencyResolver, IDependencyResolver
    {
        protected IServiceProvider serviceProvider;
        protected IServiceScope scope = null;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public DependencyResolver(IServiceScope scope)
        {
            this.scope = scope;
            serviceProvider = scope.ServiceProvider;
        }

        public IDependencyScope BeginScope()
        {
            return new DependencyResolver(serviceProvider.CreateScope());
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            scope?.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return serviceProvider.GetServices(serviceType);
        }
    }
}