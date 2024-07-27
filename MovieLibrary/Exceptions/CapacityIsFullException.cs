using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    public class CapacityIsFullException : Exception
    {
        public CapacityIsFullException(string message):base(message) { }

    }
}
