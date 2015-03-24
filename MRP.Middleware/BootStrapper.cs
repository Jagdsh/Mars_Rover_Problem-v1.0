using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Middleware.Service;
using StructureMap;

namespace MRP.Middleware
{
    public class BootStrapper
    {
        public static void Register()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<Initialize>().HybridHttpOrThreadLocalScoped().Use<Initialize>();
                x.For<Segregator>().HybridHttpOrThreadLocalScoped().Use<Segregator>();
            });
        }
    }
}
