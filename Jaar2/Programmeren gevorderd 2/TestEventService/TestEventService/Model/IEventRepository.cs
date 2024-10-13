using Microsoft.AspNetCore.Mvc;

namespace TestEventService.Model
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        IEnumerable<Event> GetEventName(string name);
        IEnumerable<Event> GetEventDate(DateTime date);
        IEnumerable<Event> GetEventLocation(string location);
        void AddEvent(Event Event);
        void RemoveEvent(string name);
        void addVisitor(string nameEvent, int visitorID);
        void removeVisitor(Event Event, Visitor visitor);


    }
}
