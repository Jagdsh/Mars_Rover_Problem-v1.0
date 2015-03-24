using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Middleware.Models;

namespace MRP.Middleware.Validators
{
    public class ValidateOrientation : IValidator
    {
        private const string OrientationErrMsg = "Invalid Orientation";
        private readonly ICollection<string> _validOrientation = Enum.GetNames(typeof(OrientationDetails.Orientation));
        public void Validate(RoverDetails roverDetails, bool validateCurrentPosition)
        {
            if (validateCurrentPosition)
            {
                if (_validOrientation.Contains(roverDetails.CurrentPosition.Orientaion.ToString()))
                    throw new Exception(OrientationErrMsg);
            }
            else
            {
                if (_validOrientation.Contains(roverDetails.FinalPosition.Orientaion.ToString()))
                    throw new Exception(OrientationErrMsg);
            }
        }
    }
}
