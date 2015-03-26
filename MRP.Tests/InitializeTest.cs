using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware.Models;
using MRP.Middleware.Processor;
using StructureMap;

namespace MRP.Tests
{
    [TestClass]
    public class InitializeTest
    {
        private readonly Initialize _initializor = ObjectFactory.GetInstance<Initialize>();
        [TestMethod]
        public void InitializeMaxPositions()
        {
            var result = _initializor.InitializeRoverDetails("5 5");
            Assert.AreEqual(result.MaximumCoordinates, new Rover() { XCoordinate = 5, YCoordinate = 5 });
        }

        [TestMethod]
        public void InitializeCurrentPositions()
        {
            _initializor.InitializeRoverDetails("5 5");
            var result = _initializor.InitializeRoverDetails("1 2 N");
            Assert.AreEqual(result.CurrentPosition, new Rover() { XCoordinate = 1, YCoordinate = 2, CompassDirection = OrientationDetails.CompassDirection.N });
        }
    }
}
