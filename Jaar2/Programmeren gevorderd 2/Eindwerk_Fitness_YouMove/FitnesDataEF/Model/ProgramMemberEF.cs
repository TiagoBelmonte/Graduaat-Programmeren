using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnesDataEF.Model
{
    public class ProgramMemberEF
    {
        public ProgramMemberEF()
        {
        }

        public ProgramMemberEF(string ProgramCode, int memberId)
        {
            programCode = ProgramCode;
            member_id = memberId;
        }

        [MaxLength(10)]
        public string programCode { get; set; }

        public int member_id { get; set; }

        [ForeignKey(nameof(programCode))]
        public ProgramEF program { get; set; }

        [ForeignKey(nameof(member_id))]
        public MemberEF member { get; set; }
    }
}
