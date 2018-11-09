using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;

namespace CarWeaverAdminTool.WebAPI.Extensions
{
    public class AutoFacDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;
        public AutoFacDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            _container.TryResolve(serviceType, out object resolved);
            return resolved;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Type type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            _container.TryResolve(type, out object resolved);
            return (IEnumerable<object>)resolved;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}