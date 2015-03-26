using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Models;

namespace MRP.Middleware.Validators
{
    public class ValidateInputFormat : IValidator
    {
        public void Validate(RoverDetails roverDetails, bool validateCurrentPosition)
        {
            if (roverDetails.MaximumCoordinates == null)
                throw new InvalidInputException("Enter Maximum Coordinates");
        }
    }
}
