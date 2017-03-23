using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using LaunchPad.Repository;

namespace LaunchPad
{
    public static class Unity
    {
        public static IUnitOfWork Work { get; set; }
        static Unity()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection)System.Configuration.ConfigurationManager.GetSection("unity");
            section.Configure(container);
            UnitOfWork.DependencyLocator = new DependencyLocator(container);
            Work = new UnitOfWork();
        }
    }
}