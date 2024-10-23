using EventServiceBL.Interfaces;
using EventServiceBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Managers
{
    public class EventManager : IEventManager
    {
        private Dictionary<string, Event> _events = new Dictionary<string, Event>();

        public EventManager()
        {
            _events.Add("MongoDB", new Event("MongoDB", DateTime.Parse("24/10/2022"), "Mercator", 50));
            _events.Add("REST service", new Event("REST service", DateTime.Parse("24/10/2022"), "Mercator", 50));
        }

        public List<Event> GetAllEvents()
        {
            return _events.Values.ToList();
        }

        public Event GetEvent(string name)
        {
            if (_events.ContainsKey(name)) return _events[name];
            else throw new Exception("GetEvent");
        }

        public List<Event> GetEventsForDate(DateTime dateTime)
        {
            return _events.Values.Where(e=>e.Date.Date==dateTime.Date).ToList();
        }

        public List<Event> GetEventsForLocation(string location)
        {
            return _events.Values.Where(e=>e.Location==location).ToList();
        }

        public void SubscribeVisitor(Visitor v, Event ev)
        {
            try
            {
                _events[ev.Name].AddVisitor(v);
            }
            catch (Exception ex) { throw new Exception("SubscribeVisitor"); }
        }
    }
}
