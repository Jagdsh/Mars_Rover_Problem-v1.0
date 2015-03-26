namespace MRP.Middleware.Models
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public OrientationDetails.CompassDirection CompassDirection { get; set; }


        protected bool Equals(Rover other)
        {
            return XCoordinate == other.XCoordinate && YCoordinate == other.YCoordinate && CompassDirection == other.CompassDirection;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = XCoordinate;
                hashCode = (hashCode*397) ^ YCoordinate;
                hashCode = (hashCode*397) ^ (int) CompassDirection;
                return hashCode;
            }
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Rover) obj);
        }
    }
}
