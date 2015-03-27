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

//https://github.com/psake/psake/wiki/How-can-I-use-psake-to-build-a-VS.NET-solution%3F
//https://github.com/psake/psake
//http://priyaaank.tumblr.com/post/95095165285/decoding-thoughtworks-coding-problems
