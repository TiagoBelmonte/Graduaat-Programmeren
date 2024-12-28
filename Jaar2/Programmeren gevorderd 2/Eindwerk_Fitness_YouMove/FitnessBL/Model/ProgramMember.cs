using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class ProgramMember
    {
        public Program programCode { get; set; }
        public Member member { get; set; }

        public string ProgramCodeString { get; set; }
        public int MemberInt { get; set; }
        public ProgramMember(Program programCode, Member member)
        {
            this.programCode = programCode;
            this.member = member;
        }

        public ProgramMember(string programCode, int member)
        {
            ProgramCodeString = programCode;
            MemberInt = member;
        }
    }
}
