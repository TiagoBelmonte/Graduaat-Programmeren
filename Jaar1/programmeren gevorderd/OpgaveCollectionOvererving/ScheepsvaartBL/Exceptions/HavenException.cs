using System.Runtime.Serialization;

namespace ScheepvaartBL.Exceptions
{
    [Serializable]
    public class HavenException : Exception
    {
        public HavenException(string? message) : base(message)
        {
        }

    }
}