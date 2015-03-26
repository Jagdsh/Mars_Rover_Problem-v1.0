using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware.Models;
using MRP.Middleware.Processor;
using StructureMap;

namespace MRP.Tests
{
    [TestClass]
    public class GetDestinationTest
    {
        private readonly Processor _processor = ObjectFactory.GetInstance<Processor>();
        [TestMethod]
        public void GetTheDestination1()
        {
            var roverDetails = new RoverDetails()
            {
                MaximumCoordinates = new Rover() { XCoordinate = 5, YCoordinate = 5 },
                CurrentPosition = new Rover() { XCoordinate = 1, YCoordinate = 2, CompassDirection = OrientationDetails.CompassDirection.N },
                RoverInstruction = "LMLMLMLMM"
            };
            var result = _processor.GetTheDestination(roverDetails);
            Assert.AreEqual(result.FinalPosition, new Rover() { XCoordinate = 1, YCoordinate = 3, CompassDirection = OrientationDetails.CompassDirection.N });
        }

        [TestMethod]
        public void GetTheDestination2()
        {
            var roverDetails = new RoverDetails()
            {
                MaximumCoordinates = new Rover() { XCoordinate = 5, YCoordinate = 5 },
                CurrentPosition = new Rover() { XCoordinate = 3, YCoordinate = 3, CompassDirection = OrientationDetails.CompassDirection.E },
                RoverInstruction = "MMRMMRMRRM"
            };
            var result = _processor.GetTheDestination(roverDetails);
            Assert.AreEqual(result.FinalPosition, new Rover() { XCoordinate = 5, YCoordinate = 1, CompassDirection = OrientationDetails.CompassDirection.E });
        }
    }
}
