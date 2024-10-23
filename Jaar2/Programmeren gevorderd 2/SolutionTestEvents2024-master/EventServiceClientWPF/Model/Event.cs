using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceClientWPF.Model
{
    public class Event
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxVisitors { get; set; }
        public List<Visitor> Visitors { get; set; }
        public override string ToString()
        {
            return $"{Name},{Date},{Location},{MaxVisitors},\n\t{string.Join("\n\t",Visitors)}";
        }

    }
}
