using System;

namespace StripsBL.Exceptions
{
    public class DomeinException : Exception
    {
        // Constructor die het bericht doorgeeft aan de basisklasse Exception
        public DomeinException(string message) : base(message)
        {
        }
    }
}
