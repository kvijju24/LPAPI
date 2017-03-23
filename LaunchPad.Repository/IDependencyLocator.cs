using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Repository
{
    public interface IDependencyLocator
    {
        T LocateDependency<T>();
    }
}
