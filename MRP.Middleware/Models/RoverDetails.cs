using MRP.Middleware.Properties;

namespace MRP.Middleware.Models
{
    public class RoverDetails
    {
        public Rover CurrentPosition { get; set; }
        public Rover FinalPosition { get; set; }
        public string RoverInstruction { get; set; }
        public string ValidationResult { get; set; }
        public bool HasValidPattern { get; set; }

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

        private string _output;
        public string Output
        {
            get
            {
                _output = (ValidationResult == null && FinalPosition != null) ?
                     string.Format(Settings.Default.OutputFormat, FinalPosition.XCoordinate,
                        FinalPosition.YCoordinate, FinalPosition.CompassDirection) : ValidationResult;

                return _output;
            }
        }

        public bool IsValid
        {
            get
            {
                return (ValidationResult == null && CurrentPosition != null);
            }
        }
    }
}
