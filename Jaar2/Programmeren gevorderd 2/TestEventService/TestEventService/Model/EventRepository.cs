using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestEventService.Model
{
    public class EventRepository : IEventRepository
    {
        private Dictionary<int, Event> events = new Dictionary<int, Event>();
        private Dictionary<int, Visitor> visitors = new Dictionary<int, Visitor>();

        

        public EventRepository()
        {
            events.Add(1, new Event(1,"ASP.NET Boot","Schoonmeersen lokaal 1.0012", new DateTime(2022 - 10 - 24), 20));
            events.Add(2, new Event(2, "Bijscholing async", "Mercator", new DateTime(2022 - 11 - 14), 10));
            events.Add(3, new Event(3, "MongoDB", "Mercator", new DateTime(2022 - 12 - 01), 4));

            visitors.Add(1, new Visitor("John", new DateTime(1975 - 03 - 12), 1));
            visitors.Add(2, new Visitor("Jane", new DateTime(1995 - 07 - 18), 2));
            visitors.Add(3, new Visitor("David", new DateTime(2001 - 04 - 02), 3));
            visitors.Add(4, new Visitor("Chris", new DateTime(1999 - 09 - 12), 4));

            
            


        }

        public IEnumerable<Event> GetAll()
        {
            return events.Values;
        }

        public IEnumerable<Event> GetEventName(string name)
        {
            return events.Values.Where(x => x.Name == name);
        }
        public IEnumerable<Event> GetEventDate(DateTime date)
        {
            return events.Values.Where(x => x.Date == date);
        }
        public IEnumerable<Event> GetEventLocation(string location)
        {
            return events.Values.Where(x => x.Location == location);
        }


        public void AddEvent(Event Event)
        {
            if (!events.ContainsKey(Event.Id))
            {
                events.Add(Event.Id, Event);
            }
            else
            {
                throw new EventException("Event already exists");
            }
        }
        public void RemoveEvent(string name)
        {
            Event Event = null;
            foreach (Event e in events.Values)
            {
                if (e.Name.ToLower() == name.ToLower())
                {
                    Event = e;
                }
            }
            if (events.ContainsKey(Event.Id))
            {
                events.Remove(Event.Id);
            }
            else
            {
                throw new EventException("Event doesn't exist anymore");
            }
        }

        public void addVisitor(string NameEvent,int visitorID)
        {
            Event Event = null;
            foreach (Event e in events.Values)
            {
                if (e.Name.ToLower() == NameEvent.ToLower())
                {
                    Event = e;
                }
            }

            Visitor visitor = null;
            foreach (int v in visitors.Keys)
            {
                if (v == visitorID)
                { 
                    visitor = visitors[v];
                }
            }
            events.ElementAt(Event.Id).Value.addVisitor(visitor);     
        }

        public void removeVisitor(Event Event, Visitor visitor)
        { 
            events.ElementAt(Event.Id).Value.removeVisitor(visitor);
        }



    }
}
