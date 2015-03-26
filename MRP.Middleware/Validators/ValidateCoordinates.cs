using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Models;

namespace MRP.Middleware.Validators
{
    public class ValidateCoordinates : IValidator
    {
        private const string ErrMsgXCoordinate = "Exceeded X Coordinate\r\n";
        private const string ErrMsgYCoordinate = "Exceeded Y Coordinate\r\n";
        private readonly StringBuilder _errMsgBuilder = new StringBuilder();
        public void Validate(RoverDetails roverDetails, bool validateCurrentPosition)
        {
            if (validateCurrentPosition)
            {
                if (roverDetails.CurrentPosition.XCoordinate > roverDetails.MaximumCoordinates.XCoordinate || roverDetails.CurrentPosition.XCoordinate < 0)
                    _errMsgBuilder.Append(ErrMsgXCoordinate);

                if (roverDetails.CurrentPosition.YCoordinate > roverDetails.MaximumCoordinates.YCoordinate || roverDetails.CurrentPosition.YCoordinate < 0)
                    _errMsgBuilder.Append(ErrMsgYCoordinate);
            }
            else
            {
                if (roverDetails.FinalPosition.XCoordinate > roverDetails.MaximumCoordinates.XCoordinate || roverDetails.FinalPosition.XCoordinate < 0)
                    _errMsgBuilder.Append(ErrMsgXCoordinate);

                if (roverDetails.FinalPosition.YCoordinate > roverDetails.MaximumCoordinates.YCoordinate || roverDetails.FinalPosition.YCoordinate < 0)
                    _errMsgBuilder.Append(ErrMsgYCoordinate);
            }

            if (_errMsgBuilder.Length > 1)
                throw new InvalidCoordinateException(_errMsgBuilder.ToString());
        }
    }
}
