using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class ProgramEF
    {
        public ProgramEF()
        {
        }

        public ProgramEF(string ProgramCode, string Name, string Target, DateTime startDate, int maxMembers, ICollection<ProgramMemberEF> ProgramMembers)
        {
            programCode = ProgramCode;
            name = Name;
            target = Target;
            startdate = startDate;
            max_members = maxMembers;
            programmembers = ProgramMembers;
        }

        [Key]
        [MaxLength(10)]
        public string programCode { get; set; }

        [Required]
        [MaxLength(45)]
        public string name { get; set; }

        [MaxLength(25)]
        public string target { get; set; }

        public DateTime startdate { get; set; }
        public int max_members { get; set; }

        public ICollection<ProgramMemberEF> programmembers { get; set; }
    }

}
