using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Exceptions;
using MRP.Middleware.Processor;
using MRP.Middleware.Properties;
using StructureMap;

namespace MRP.Middleware
{
    public class Segregator
    {
        private readonly Initialize _initializor = ObjectFactory.GetInstance<Initialize>();
        private readonly Regex _orientationPattern = new Regex(Settings.Default.orientationPattern);
        private readonly Regex _maxPositionPattern = new Regex(Settings.Default.maxPositionPattern);
        private readonly Regex _currentPositionPattern = new Regex(Settings.Default.currentPositionPattern);

        public void Segregate(string input)
        {
            try
            {
                if (_maxPositionPattern.IsMatch(input))
                    _initializor.PopulateMaxPositionDetails(input);
                else if (_currentPositionPattern.IsMatch(input))
                    _initializor.PopulateCurrentPositionDetails(input);
                else if (_orientationPattern.IsMatch(input))
                    _initializor.GetTheDestinationDetails(input);
                else
                    throw new InvalidInputException("Invalid Input");
            }
            catch (InvalidInputException exception)
            {                
                Console.WriteLine(exception.Message);
            }
        }
    }
}
