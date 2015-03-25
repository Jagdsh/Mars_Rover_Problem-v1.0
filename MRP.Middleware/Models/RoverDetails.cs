using MRP.Middleware.Properties;

namespace MRP.Middleware.Models
{
    public class RoverDetails
    {
        public Rover CurrentPosition { get; set; }
        public Rover FinalPosition { get; set; }
        public string RoverInstruction { get; set; }

        private Rover _maxDetails;

        public Rover MaximumCoordinates
        {
            get { return _maxDetails; }
            set
            {
                if (_maxDetails == null)
                    _maxDetails = value;
            }
        }

        public string Output
        {
            get
            {
                return string.Format(Settings.Default.OutputFormat, FinalPosition.XCoordinate,
                    FinalPosition.YCoordinate, FinalPosition.CompassDirection);
            }
        }
    }
}
