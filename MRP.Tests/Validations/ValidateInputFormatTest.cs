using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Models;
using MRP.Middleware.Validators;
using StructureMap;

namespace MRP.Tests.Validations
{
    [TestClass]
    public class ValidateInputFormatTest
    {
        private ValidateInputFormat _validate;

        [TestInitialize]
        public void SetUp()
        {
            _validate = ObjectFactory.GetInstance<ValidateInputFormat>();
        }

        [ExpectedException(typeof(InvalidInputException))]
        [TestMethod]
        public void ShouldValidateInputFormat()
        {
            _validate.Validate(new RoverDetails(), true);
        }
    }
}
