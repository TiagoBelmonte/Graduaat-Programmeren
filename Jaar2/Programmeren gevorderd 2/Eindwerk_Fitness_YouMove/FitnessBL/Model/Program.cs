using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Program
    {
        // Eigenschappen
        public string programCode { get; set; }
        public string name { get; set; }
        public string target { get; set; }
        public DateTime startDate { get; set; }
        public int max_members { get; set; }
        public List<Member> Members { get; set; }

        // Constructor
        public Program(string programCode, string name, string target, DateTime startDate, int maxMembers, List<Member> members)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new DomeinExceptions("Name mag niet leeg zijn.");
            //}

            //if (string.IsNullOrWhiteSpace(target))
            //{
            //    throw new DomeinExceptions("Target mag niet leeg zijn.");
            //}

            //if (startDate < DateTime.Now)
            //{
            //    throw new DomeinExceptions("Startdate mag niet in het verleden liggen.");
            //}

            //if (maxMembers <= 0)
            //{
            //    throw new DomeinExceptions("MaxMembers moet groter dan 0 zijn.");
            //}

            this.programCode = programCode;
            this.name = name;
            this.target = target;
            this.startDate = startDate;
            max_members = maxMembers;
            Members = members ?? new List<Member>(); // Zorg ervoor dat Members nooit null is
        }
    }
}
