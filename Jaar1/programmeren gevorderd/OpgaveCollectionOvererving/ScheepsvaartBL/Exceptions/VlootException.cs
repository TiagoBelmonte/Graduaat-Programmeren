using System.Runtime.Serialization;

namespace ScheepvaartBL.Exceptions
{
    [Serializable]
    public class VlootException : Exception
    {

        public VlootException(string? message) : base(message)
        {
        }
    }
}