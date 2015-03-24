using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Properties;
using MRP.Middleware.Service;

namespace MRP.Middleware
{
    public class Segregator
    {
        private readonly Initialize _initializor;        
        public Segregator()
        {
            _initializor = new Initialize();
        }

        public void Segregate(string input)
        {
            var maxPositionPattern = new Regex(Settings.Default.maxPositionPattern);
            var currentPositionPattern = new Regex(Settings.Default.currentPositionPattern);
            var orientationPattern = new Regex(Settings.Default.orientationPattern);
            try
            {
                if (maxPositionPattern.IsMatch(input))
                    _initializor.PopulateMaxPositionDetails(input);
                else if (currentPositionPattern.IsMatch(input))
                    _initializor.PopulateCurrentPositionDetails(input);
                else if (orientationPattern.IsMatch(input))
                    _initializor.GetTheDestinationDetails(input);
            }
            catch (InvalidInputException)
            {
                throw new InvalidInputException("Invalid Input Exception");
            }
        }
    }
}
