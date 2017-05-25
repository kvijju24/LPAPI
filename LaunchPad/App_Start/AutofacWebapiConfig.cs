using Autofac;
using Autofac.Integration.WebApi;
using LaunchPad.Data;
using LaunchPad.Data.Infrastructure;
using LaunchPad.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace LaunchPad.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // EF HomeCinemaContext
            builder.RegisterType<LPDataContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
            builder.RegisterGeneric(typeof(EntityBaseRepository<>))
                   .As(typeof(IEntityBaseRepository<>))
                   .InstancePerRequest();
            //// Services
            //builder.RegisterType<EncryptionService>()
            //    .As<IEncryptionService>()
            //    .InstancePerRequest();
            //builder.RegisterType<SecurityService>()
            //    .As<ISecurityService>()
            //    .InstancePerRequest();
            Container = builder.Build();
            return Container;
        }
    }
}