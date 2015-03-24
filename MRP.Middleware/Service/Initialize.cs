using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Models;
using MRP.Middleware.Properties;

namespace MRP.Middleware.Service
{
    public class Initialize
    {
        private readonly RoverDetails _roverDetails;
        public Initialize()
        {
            _roverDetails = new RoverDetails();
        }

        public RoverDetails InitializeDetails(string maxPositions, string currentPositions, string instructions)
        {
            var regex = new Regex(Settings.Default.maxPositionPattern);
            var sample = regex.Match(maxPositions);
            var newdf = new Rover
            {
                XCoordinate = int.Parse(sample.Groups["xcoordinate"].Value),
                YCoordinate = int.Parse(sample.Groups["ycoordinate"].Value)
            };

            _roverDetails.MaximumPosition = newdf;
            return _roverDetails;
        }
    }
}
