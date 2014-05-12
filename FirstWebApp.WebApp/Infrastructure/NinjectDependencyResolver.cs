using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using FirstWebApp.Repository.Interfaces;
using FirstWebApp.Repository;

namespace FirstWebApp.Infrastructure
{
    

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepositoryRegistratedMembers>().To<RepositoryRegistratedMembers>();
        }
    }
}