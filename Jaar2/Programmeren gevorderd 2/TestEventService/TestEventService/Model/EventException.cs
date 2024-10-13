namespace TestEventService.Model
{
    public class EventException : Exception
    {
        public EventException(string? message) : base(message) { }
    }
}
