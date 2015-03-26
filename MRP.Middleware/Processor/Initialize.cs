using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MRP.Middleware.Exceptions;
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
        private readonly Regex _maxPositionPattern = new Regex(Settings.Default.maxPositionPattern);
        private readonly Regex _currentPositionPattern = new Regex(Settings.Default.currentPositionPattern);

        public Initialize(ValidationProvider validationProvider, RoverDetails roverDetails)
        {
            _roverDetails = roverDetails;
            _validators = validationProvider.GetValidators();
        }

        public RoverDetails InitializeRoverDetails(string input)
        {
            if (_maxPositionPattern.IsMatch(input))
                PopulateMaxPositionDetails(input);
            else if (_currentPositionPattern.IsMatch(input))
                PopulateCurrentPositionDetails(input);
            else
                _roverDetails.HasValidPattern = false;

            return _roverDetails;
        }

        public void PopulateMaxPositionDetails(string maxCoordinates)
        {
            var regexMatch = _maxPositionPattern.Match(maxCoordinates);

            _roverDetails.MaximumCoordinates = new Rover
            {
                XCoordinate = int.Parse(regexMatch.Groups["xcoordinate"].Value),
                YCoordinate = int.Parse(regexMatch.Groups["ycoordinate"].Value)
            };
            _roverDetails.HasValidPattern = true;
        }

        public void PopulateCurrentPositionDetails(string currentPosition)
        {
            var regexMatch = _currentPositionPattern.Match(currentPosition);

            _roverDetails.CurrentPosition = new Rover
            {
                XCoordinate = int.Parse(regexMatch.Groups["xcoordinate"].Value),
                YCoordinate = int.Parse(regexMatch.Groups["ycoordinate"].Value),
                CompassDirection = (OrientationDetails.CompassDirection)Enum.Parse(typeof(OrientationDetails.CompassDirection), regexMatch.Groups["orientation"].Value)
            };
            _roverDetails.HasValidPattern = true;

            _validators.ForEach(x => x.Validate(_roverDetails, true));
        }

        public RoverDetails GetTheDestinationDetails(string instruction)
        {
            if (!_roverDetails.IsValid)
                throw new InvalidInputException("Invalid Input");

            _roverDetails.RoverInstruction = instruction;
            _processor.GetTheDestination(_roverDetails);
            _validators.ForEach(x => x.Validate(_roverDetails, false));

            return _roverDetails;
        }
    }
}
