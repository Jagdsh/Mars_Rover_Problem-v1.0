using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MRP.Middleware.Properties;

namespace MRP.Middleware
{
    public class Segregator
    {
        public void Segregate(string input)
        {
            var maxPositionPattern = new Regex(Settings.Default.maxPositionPattern);
            var currentPositionPattern = new Regex(Settings.Default.currentPositionPattern);
            var orientationPattern = new Regex(Settings.Default.orientationPattern);
            if (maxPositionPattern.IsMatch(input))
            {

            }
            else if (currentPositionPattern.IsMatch(input))
            {

            }
            else if (orientationPattern.IsMatch(input))
            {

            }
            else
            {

            }
        }
    }
}
