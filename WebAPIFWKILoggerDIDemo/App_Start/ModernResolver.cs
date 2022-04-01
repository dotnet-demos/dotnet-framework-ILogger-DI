using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebAPIFWKILoggerDIDemo
{
    internal class ModernResolver : IDependencyResolver
    {
        IServiceProvider services;
        private bool disposedValue;
        public ModernResolver(IServiceProvider services)
        {
            this.services = services;
        }
        IDependencyScope IDependencyResolver.BeginScope()
        {
            return new ModernResolver(services.CreateScope().ServiceProvider);
        }

        object IDependencyScope.GetService(Type serviceType)
        {
            return services.GetService(serviceType);
        }

        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            return services.GetServices(serviceType);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ModernResolver()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
