using EventServiceBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Interfaces
{
    public interface IEventManager
    {
        List<Event> GetAllEvents();
        Event GetEvent(string name);
        List<Event> GetEventsForDate(DateTime dateTime);
        List<Event> GetEventsForLocation(string location);
        void SubscribeVisitor(Visitor v, Event ev);
    }
}
