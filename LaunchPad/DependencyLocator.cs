using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using LaunchPad.Repository;
namespace LaunchPad
{
    public class DependencyLocator : IDependencyLocator
    {
        private readonly IUnityContainer _container;
        public DependencyLocator(IUnityContainer container)
        {
            _container = container;
        }
        public T LocateDependency<T>()
        {
            return (T)_container.Resolve<T>();
        }
    }
}