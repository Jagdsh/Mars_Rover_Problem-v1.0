using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Models;
using MRP.Middleware.Properties;
using StructureMap;

namespace MRP.Middleware.Service
{
    public class Initialize
    {
        private readonly RoverDetails _roverDetails;
        private readonly Processor.Processor _processor = ObjectFactory.GetInstance<Processor.Processor>();
        public Initialize()
        {
            _roverDetails = new RoverDetails();
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
                Orientaion = (OrientationDetails.Orientation)Enum.Parse(typeof(OrientationDetails.Orientation), regexMatch.Groups["orientation"].Value)
            };
        }

        public void GetTheDestinationDetails(string instruction)
        {
            _roverDetails.RoverInstruction = instruction;
            _processor.GetTheDestination(_roverDetails);
        }
    }
}
