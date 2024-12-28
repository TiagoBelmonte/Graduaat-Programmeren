using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class ProgramMembersService
    {
        private IProgramMembersRepo repo;
        public ProgramMembersService(IProgramMembersRepo repo)
        {
            this.repo = repo;
        }
        public List<ProgramMember> GetProgramMembersByMemberId(int memberid)
        {
            try
            {
                return repo.GetProgramMembersByMemberId(memberid);
            }
            catch (Exception)
            {
                throw new Exception("GetProgramMembersByMemberId");
            }
        }
    }
}
