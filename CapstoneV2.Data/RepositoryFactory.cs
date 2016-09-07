using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.Data
{
    public static class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            switch (ConfigurationManager.AppSettings["BuildMode"])
            {
                case "TEST":
                    return new InMemoryRepository();
                case "PROD":
                    return new DbRepository();
                default:
                    throw new Exception("Build mode not recognized.");
            }
        }
    }
}
