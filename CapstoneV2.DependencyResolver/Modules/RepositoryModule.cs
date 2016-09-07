using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Data;
using CapstoneV2.Models.Interfaces;
using Ninject.Modules;

namespace CapstoneV2.DependencyResolver.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<InMemoryRepository>();
        }
    }
}
