using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Exceptions
{
    public class RederijException : Exception
    {
        public RederijException(string? message) : base(message)
        {
        }

        public RederijException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
