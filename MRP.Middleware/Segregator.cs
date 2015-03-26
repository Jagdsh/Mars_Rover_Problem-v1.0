using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Models;
using MRP.Middleware.Processor;
using MRP.Middleware.Properties;
using StructureMap;

namespace MRP.Middleware
{
    public class Segregator
    {
        private readonly Initialize _initializor = ObjectFactory.GetInstance<Initialize>();
        private RoverDetails _roverDetails;
        private readonly Regex _orientationPattern = new Regex(Settings.Default.orientationPattern);


        public Segregator(RoverDetails roverDetails)
        {
            _roverDetails = roverDetails;
        }

        public string Segregate(string input)
        {
            try
            {
                _roverDetails = _initializor.InitializeRoverDetails(input.Trim());
                if (_orientationPattern.IsMatch(input))
                    _roverDetails = _initializor.GetTheDestinationDetails(input.Trim());
                else if (!_roverDetails.HasValidPattern)
                    throw new InvalidInputException("Invalid Input");
            }
            catch (InvalidInputException exception)
            {
                _roverDetails.ValidationResult = exception.Message;
            }
            catch (InvalidCoordinateException exception)
            {
                _roverDetails.ValidationResult = exception.Message;
            }

            return _roverDetails.Output;
        }
    }
}
