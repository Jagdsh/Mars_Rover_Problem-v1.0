using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRP.Middleware.Exceptions
{
    public class InvalidCoordinateException : Exception
    {
        public InvalidCoordinateException(string message)
            : base(message)
        {

        }
    }
}
