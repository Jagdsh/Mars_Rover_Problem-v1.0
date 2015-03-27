using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using MRP.Middleware;

namespace Mars_Rover_Problem_v1._0
{
    class Program
    {
        private static readonly Segregator Segregator = ObjectFactory.GetInstance<Segregator>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Segregator.Segregate(Console.ReadLine()));
            }
        }
    }
}
