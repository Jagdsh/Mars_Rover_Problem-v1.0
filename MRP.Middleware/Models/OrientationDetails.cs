using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Middleware.Models
{
    public class OrientationDetails
    {        
        public enum CompassDirection
        {            
            N = 0,
            E = 1,
            S = 2,
            W = 3,            
        }

        public enum Orientation
        {
            L,
            R            
        }
    }
}
