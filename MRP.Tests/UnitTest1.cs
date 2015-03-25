using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware;
using MRP.Middleware.Service;

namespace MRP.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Validators()
        {
            //var initializor = new Initialize();
            //initializor.InitializeDetails("5 78", "4 5 N", "LMLMLMLMLMM");
            var segregator = new Segregator();
            segregator.Segregate("5 5");
            segregator.Segregate("1 2 N");
            segregator.Segregate("LMLMLMLMLMM");
        }
    }
}
