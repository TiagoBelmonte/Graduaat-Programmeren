using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;


namespace TestEventService.Model
{
    public class VisitorRepository : IVisitorsRepository
    {
        public Dictionary<int,Visitor> visitors = new Dictionary<int, Visitor>();

        public VisitorRepository()
        {
            visitors.Add(1,new Visitor("John", new DateTime(1975-03-12), 1));
            visitors.Add(2, new Visitor("Jane", new DateTime(1995 - 07 - 18), 2));
            visitors.Add(3, new Visitor("David", new DateTime(2001 - 04 - 02), 3));
            visitors.Add(4, new Visitor("Chris", new DateTime(1999 - 09 - 12), 4));

        }

        public IEnumerable<Visitor> GetAll()
        {
            return visitors.Values;
        }

        public Visitor GetVisitor(int id)
        {
            if (visitors.ContainsKey(id))
                return visitors[id];
            else
                throw new VisitorExceptions("Visitor doesn't exist in this list");
        }

        public void AddVistor(Visitor visitor)
        {
            if (!visitors.ContainsKey(visitor.Id))
                visitors.Add(visitor.Id, visitor);
            else
                throw new VisitorExceptions("visitor is already added");
        }
    }
}
