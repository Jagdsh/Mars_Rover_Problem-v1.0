using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware;
using StructureMap;

namespace MRP.Tests
{
    [TestClass]
    public class UnitTest
    {
        private readonly Segregator _segregator = ObjectFactory.GetInstance<Segregator>();

        [TestMethod]
        public void FinalOutput1()
        {
            _segregator.Segregate("5 5");
            _segregator.Segregate("3 3 E");
            var result = _segregator.Segregate("MMRMMRMRRM");
            Assert.AreEqual(result, "5 1 E");
        }

        [TestMethod]
        public void FinalOutput2()
        {
            _segregator.Segregate("5 5");
            _segregator.Segregate("1 2 N");
            var result = _segregator.Segregate("LMLMLMLMM");
            Assert.AreEqual(result, "1 3 N");
        }

        [TestMethod]
        public void ShouldEnterMaxCoordinates()
        {
            var result = _segregator.Segregate("1 2 N");
            Assert.AreEqual(result, "Enter Maximum Coordinates");
        }

        [TestMethod]
        public void ShouldValidateCurExceededCoordinates()
        {
            _segregator.Segregate("5 5");
            var result = _segregator.Segregate("7 7 N");
            Assert.AreEqual(result, "Exceeded X Coordinate\r\nExceeded Y Coordinate\r\n");
        }

        [TestMethod]
        public void ShouldValidateFinalExceededCoordinates()
        {
            _segregator.Segregate("5 5");
            _segregator.Segregate("1 2 N");
            var result = _segregator.Segregate("RMMMMMM");
            Assert.AreEqual(result, "Exceeded X Coordinate\r\n");
        }
    }
}
