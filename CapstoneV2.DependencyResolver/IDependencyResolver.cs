using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace CapstoneV2.DependencyResolver
{
    public interface IDependencyResolver
    {
        INinjectModule[] GetModules();
    }
}
