using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class ProgramMemberEF
    {
        public ProgramMemberEF()
        {
        }

        public ProgramMemberEF(int programMemberId, string programCode, int memberId, ProgramEF program, MemberEF member)
        {
            ProgramMemberId = programMemberId;
            ProgramCode = programCode;
            MemberId = memberId;
            Program = program;
            Member = member;
        }

        [Key]
        public int ProgramMemberId { get; set; }

        [Required]
        [MaxLength(10)]
        public string ProgramCode { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey(nameof(ProgramCode))]
        public ProgramEF Program { get; set; }

        [ForeignKey(nameof(MemberId))]
        public MemberEF Member { get; set; }
    }

}
