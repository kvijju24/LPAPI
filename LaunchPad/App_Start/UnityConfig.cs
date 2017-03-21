using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using LaunchPad.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
            container.RegisterType<DbContext, ESEntities>((new HierarchicalLifetimeManager()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}