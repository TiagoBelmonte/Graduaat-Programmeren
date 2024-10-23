using EventServiceBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Interfaces
{
    public interface IVisitorManager
    {
        List<Visitor> GetAllVisitor();
        Visitor GetVisitor(int id);
        Visitor RegisterVisitor(Visitor visitor);
        void SubscribeVisitor(Visitor visitor);
    }
}
