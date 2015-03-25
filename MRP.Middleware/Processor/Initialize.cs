using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MRP.Middleware.Models;
using MRP.Middleware.Properties;
using MRP.Middleware.Validators;
using StructureMap;

namespace MRP.Middleware.Processor
{
    public class Initialize
    {
        private readonly RoverDetails _roverDetails;
        private readonly Processor _processor = ObjectFactory.GetInstance<Processor>();
        private readonly List<IValidator> _validators;
        public Initialize(ValidationProvider validationProvider,RoverDetails roverDetails)
        {
            _roverDetails = roverDetails;
            _validators = validationProvider.GetValidators();
        }

        public void PopulateMaxPositionDetails(string maxCoordinates)
        {
            var pattern = new Regex(Settings.Default.maxPositionPattern);

            var regexMatch = pattern.Match(maxCoordinates);

            _roverDetails.MaximumCoordinates = new Rover
            {
                XCoordinate = int.Parse(regexMatch.Groups["xcoordinate"].Value),
                YCoordinate = int.Parse(regexMatch.Groups["ycoordinate"].Value)
            };
        }

        public void PopulateCurrentPositionDetails(string currentPosition)
        {
            var pattern = new Regex(Settings.Default.currentPositionPattern);

            var regexMatch = pattern.Match(currentPosition);

            _roverDetails.CurrentPosition = new Rover
            {
                XCoordinate = int.Parse(regexMatch.Groups["xcoordinate"].Value),
                YCoordinate = int.Parse(regexMatch.Groups["ycoordinate"].Value),
                CompassDirection = (OrientationDetails.CompassDirection)Enum.Parse(typeof(OrientationDetails.CompassDirection), regexMatch.Groups["orientation"].Value)
            };

            _validators.ForEach(x => x.Validate(_roverDetails, true));
        }

        public void GetTheDestinationDetails(string instruction)
        {
            _roverDetails.RoverInstruction = instruction;
            _processor.GetTheDestination(_roverDetails);

            _validators.ForEach(x => x.Validate(_roverDetails, false));

            Console.WriteLine(_roverDetails.Output);
        }
    }
}
