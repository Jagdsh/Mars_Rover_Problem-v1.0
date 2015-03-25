using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware;

namespace MRP.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Validators()
        {
            //var initializor = new Initialize();
            //initializor.InitializeDetails("5 78", "4 5 N", "LMLMLMLMLMM");
            var segregator = new Segregator();
            segregator.Segregate("5 5");
            segregator.Segregate("3 3 E");
            segregator.Segregate("MMRMMRMRRM");
        }
    }
}
