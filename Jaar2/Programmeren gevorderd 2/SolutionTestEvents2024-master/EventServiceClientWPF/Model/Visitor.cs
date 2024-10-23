using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceClientWPF.Model
{
    public class Visitor
    {
        public Visitor()
        {
        }

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Name},{Id}";
        }
    }
}
