using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinCentrumBL.Exceptions
{
    public class DomeinException : Exception
    {
        public DomeinException(string? message) : base(message)
        {
        }
    }
}
