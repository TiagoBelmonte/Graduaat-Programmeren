using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapProgramMembers
    {
        public ProgramMember MapToDomain(ProgramMemberEF db)
        {
            try
            {
                return new ProgramMember(MapProgram.MapToDomain(db.program),MapMember.MapToDomain(db.member));
            }
            catch (Exception)
            {

                throw new Exception("MapProgram - mapToDomain");
            }

        }

        public ProgramMemberEF mapToDB(ProgramMember P)
        {
            try
            {
                return new ProgramMemberEF(P.programCode.programCode, (int)P.member.member_id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Program P model to ProgramEF.", ex);
            }
        }
    }
}
