using FitnessBL.Enum;
using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Member
    {
        public int? member_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public KlantType membertype { get; set; } // Gebruik het KlantType enum
        public List<string> interests { get; set; }

        public Member(int? member_id, string first_name, string last_name, string email, string address, DateTime birthday, KlantType membertype, List<string> interests)
        {
            this.member_id = member_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.address = address;
            this.birthday = birthday;
            this.membertype = membertype; // Gebruik KlantType
            this.interests = interests;
        }
    }



}

