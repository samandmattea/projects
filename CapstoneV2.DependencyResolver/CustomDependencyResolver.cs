using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.DependencyResolver.Modules;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace CapstoneV2.DependencyResolver
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        public INinjectModule[] GetModules()
        {
            var modules = new INinjectModule[]
            {
                new ServiceModule(),
                
            };
            return modules;
        }
    }
}
