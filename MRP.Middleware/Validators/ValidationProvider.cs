using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace MRP.Middleware.Validators
{
    public class ValidationProvider
    {
        public virtual List<IValidator> GetValidators()
        {
            return new List<IValidator>()
            {
                ObjectFactory.GetInstance<ValidateInputFormat>(),
                ObjectFactory.GetInstance<ValidateCoordinates>()                
            };
        }
    }
}
