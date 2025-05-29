using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
    public class Member
    {
        public int Member_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}
