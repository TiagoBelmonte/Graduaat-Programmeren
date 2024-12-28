using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IProgramMembersRepo
    {
        List<ProgramMember> GetProgramMembersByMemberId(int memberid);
    }
}
