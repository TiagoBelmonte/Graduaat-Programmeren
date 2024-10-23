using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Model
{
    public class Event
    {
        private Dictionary<int, Visitor> _visitors=new Dictionary<int, Visitor>();

        public Event(string name, DateTime date, string location, int maxVisitors)
        {
            Name = name;
            Date = date;
            Location = location;
            MaxVisitors = maxVisitors;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxVisitors { get; set; }
        public IReadOnlyList<Visitor> Visitors => _visitors.Values.ToList().AsReadOnly();
        public void AddVisitor(Visitor visitor) {
            if (visitor == null) throw new Exception("AddVisitor");
            if (_visitors.ContainsKey(visitor.Id)) throw new Exception("AddVisitor");
            if (_visitors.Values.Count == MaxVisitors) throw new Exception("AddVisitor");
            _visitors.Add(visitor.Id, visitor);
        }
    }
}
