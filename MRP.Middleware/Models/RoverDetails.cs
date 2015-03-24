namespace MRP.Middleware.Models
{
    public class RoverDetails
    {        
        public Rover RoverMaximumCoordinates { get; internal set; }
        public Rover CurrentPosition { get; set; }
        public Rover FinalPosition { get; set; }
        public string RoverInstruction { get; set; }

        private Rover _maxDetails;
        public Rover MaximumPosition
        {
            get { return _maxDetails; }
            set
            {
                if (_maxDetails == null)
                    _maxDetails = value;
            }
        }
    }
}
