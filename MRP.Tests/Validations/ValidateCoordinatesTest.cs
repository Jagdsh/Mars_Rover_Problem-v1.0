using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Models;
using MRP.Middleware.Validators;
using StructureMap;

namespace MRP.Tests.Validations
{
    [TestClass]
    public class ValidateCoordinatesTest
    {
        private ValidateCoordinates _validate;

        [TestInitialize]
        public void SetUp()
        {
            _validate = ObjectFactory.GetInstance<ValidateCoordinates>();
        }

        [ExpectedException(typeof(InvalidCoordinateException))]
        [TestMethod]
        public void ShouldValidateInvalidCurrentPosition()
        {
            var roverDetails = new RoverDetails
            {
                MaximumCoordinates = new Rover() { XCoordinate = 5, YCoordinate = 5 },
                CurrentPosition =
                    new Rover()
                    {
                        XCoordinate = 6,
                        YCoordinate = 7,
                        CompassDirection = OrientationDetails.CompassDirection.N
                    }
            };
            _validate.Validate(roverDetails, true);
        }

        [ExpectedException(typeof(InvalidCoordinateException))]
        [TestMethod]
        public void ShouldValidateInvalidFinalPosition()
        {
            var roverDetails = new RoverDetails
            {
                MaximumCoordinates = new Rover() { XCoordinate = 5, YCoordinate = 5 },
                FinalPosition = 
                    new Rover()
                    {
                        XCoordinate = 6,
                        YCoordinate = 7,
                        CompassDirection = OrientationDetails.CompassDirection.N
                    }
            };
            _validate.Validate(roverDetails, false);
        }
    }
}
