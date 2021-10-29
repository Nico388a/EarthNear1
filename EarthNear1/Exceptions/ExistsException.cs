using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Exceptions
{
    public class ExistsException: Exception
    {
        public ExistsException(string message) : base(message)
        {
            
        }
    }
}
