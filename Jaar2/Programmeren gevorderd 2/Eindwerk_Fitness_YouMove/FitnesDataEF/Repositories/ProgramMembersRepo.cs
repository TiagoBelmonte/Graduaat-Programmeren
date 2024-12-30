using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Repositories
{
    public class ProgramMembersRepo : IProgramMembersRepo
    {
        private FitnessContext ctx;
        private MapProgramMembers mapProgramMembers;
        private MapMember mapMembers;
        private MemberRepo memberRepo;

        public ProgramMembersRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
            this.mapProgramMembers = new MapProgramMembers();
            this.mapMembers = new MapMember();
            this.memberRepo = new MemberRepo(connectionString);
        }
        public List<ProgramMember> GetProgramMembersByMemberId(int memberid)
        {
            try
            {
                List<ProgramMemberEF> programMemberEFs = ctx.programmembers.Where(x => x.member_id == memberid).ToList();
                List<ProgramMember> programMembers = new List<ProgramMember>();

                if (!programMemberEFs.Any())
                    throw new Exception($"Geen Programmas gevonden met ID {memberid}.");

                foreach (ProgramMemberEF programMember in programMemberEFs)
                {
                    programMembers.Add(GetProgramMember(programMember.programCode));
                }
                return programMembers;

            }
            catch (Exception)
            {

                throw new Exception("ProgramMembersRepo - GetProgramMembersByMemberId");
            }
        }

        public ProgramMember GetProgramMember(string id)
        {
            ProgramMemberEF programMemberEF = ctx.programmembers.Where(x => x.programCode.Equals(id)).FirstOrDefault();
            programMemberEF.program = ctx.program.Where(x => x.programCode.Equals(programMemberEF.programCode)).FirstOrDefault();
            programMemberEF.member = ctx.members.Where(x => x.member_id == programMemberEF.member_id).FirstOrDefault();
            return mapProgramMembers.MapToDomain(programMemberEF);
        }
    }
}
