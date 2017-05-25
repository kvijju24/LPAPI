using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using LaunchPad.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LaunchPad.Repository;

namespace LaunchPad
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDbContext, LPDataContext>((new HierarchicalLifetimeManager()));
            container.RegisterType<IDbContext, ClientDataContext>((new HierarchicalLifetimeManager()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
            UnitOfWork.DependencyLocator = new DependencyLocator(container);
            ClientUnitOfWork.DependencyLocator = new DependencyLocator(container);
        }
    }
}