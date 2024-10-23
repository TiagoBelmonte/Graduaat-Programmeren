using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceBL.Model
{
    public class Visitor
    {
        public Visitor(string name, DateTime birthDay, int id)
        {
            Name = name;
            BirthDay = birthDay;
            Id = id;
        }

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Id { get; set; }
    }
}
