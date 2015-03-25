namespace MRP.Middleware.Models
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public OrientationDetails.CompassDirection CompassDirection { get; set; }
    }
}
