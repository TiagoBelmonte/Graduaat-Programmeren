using EventServiceBL.Interfaces;
using EventServiceBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Managers
{
    public class VisitorManager : IVisitorManager
    {
        private int _id=1;
        private  Dictionary<int, Visitor> _visitors = new Dictionary<int, Visitor>();

        public VisitorManager()
        {
            _visitors.Add(_id, new Visitor("John", DateTime.Parse("12/3/1975"), _id++));
            _visitors.Add(_id, new Visitor("Jane", DateTime.Parse("18/7/1995"), _id++));
            _visitors.Add(_id, new Visitor("David", DateTime.Parse("2/4/2001"), _id++));
            _visitors.Add(_id, new Visitor("Chris", DateTime.Parse("12/9/1999"), _id++));
        }

        public List<Visitor> GetAllVisitor()
        {
            return _visitors.Values.ToList();
        }

        public Visitor GetVisitor(int id)
        {
            if (_visitors.ContainsKey(id)) return _visitors[id];
            else throw new Exception("GetVisitor");
        }

        public Visitor RegisterVisitor(Visitor visitor)
        {
            visitor.Id = _id++;
            return visitor;
        }

        public void SubscribeVisitor(Visitor visitor)
        {
            if (visitor == null) { throw new Exception("SubscribeVisitor"); }
            if (_visitors.ContainsKey(visitor.Id)) { throw new Exception("SubscribeVisitor"); }
            _visitors.Add(visitor.Id, visitor);
        }
    }
}
