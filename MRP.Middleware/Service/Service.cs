using MRP.Middleware.Models;

namespace MRP.Middleware.Service
{
    public class Service
    {
        private const string OutputString = "{0} {1} {2}";
        public string BuildOutput(RoverDetails roverDetails)
        {
            return string.Format(OutputString, roverDetails.FinalPosition.XCoordinate,
                roverDetails.FinalPosition.YCoordinate, roverDetails.FinalPosition.Orientaion);
        }
    }
}
