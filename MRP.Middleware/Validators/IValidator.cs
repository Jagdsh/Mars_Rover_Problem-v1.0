using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Middleware.Models;

namespace MRP.Middleware.Validators
{
    public interface IValidator
    {
        void Validate(RoverDetails roverDetails,bool validateCurrentPosition);
    }
}
