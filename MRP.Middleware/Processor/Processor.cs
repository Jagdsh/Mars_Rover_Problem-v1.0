using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Middleware.Models;

namespace MRP.Middleware.Processor
{
    public class Processor
    {
        private static readonly List<string> ValidOrientation =
            Enum.GetNames(typeof(OrientationDetails.Orientation)).ToList();
        private Rover _rover;

        public RoverDetails GetTheDestination(RoverDetails roverDetails)
        {
            _rover = roverDetails.CurrentPosition;
            foreach (var command in roverDetails.RoverInstruction)
            {
                if (ValidOrientation.Contains(command.ToString()))
                    ChangeOrientation(command);
                else
                    MoveForward();
            }

            roverDetails.FinalPosition = _rover;
            return roverDetails;
        }

        public void ChangeOrientation(char command)
        {
            var currentDirection = _rover.CompassDirection;
            if (command.ToString() == OrientationDetails.Orientation.R.ToString())
                _rover.CompassDirection =
                    (OrientationDetails.CompassDirection)(((int)currentDirection + 1) % 4);
            else
            {
                var calculatedDirection =
                    ((int)_rover.CompassDirection - 1);

                _rover.CompassDirection = calculatedDirection == -1
                    ? OrientationDetails.CompassDirection.W
                    : (OrientationDetails.CompassDirection)calculatedDirection;
            }
        }

        public void MoveForward()
        {
            var currentPosition = _rover;
            switch (currentPosition.CompassDirection)
            {
                case OrientationDetails.CompassDirection.N:
                    _rover.YCoordinate = currentPosition.YCoordinate + 1;
                    break;
                case OrientationDetails.CompassDirection.E:
                    _rover.XCoordinate = currentPosition.XCoordinate + 1;
                    break;
                case OrientationDetails.CompassDirection.S:
                    _rover.YCoordinate = currentPosition.YCoordinate - 1;
                    break;
                case OrientationDetails.CompassDirection.W:
                    _rover.XCoordinate = currentPosition.XCoordinate - 1;
                    break;
            }
        }
    }
}
