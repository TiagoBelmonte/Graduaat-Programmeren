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

        public ProgramEF(string programCode, string name, string target, DateTime startDate, int maxMembers, ICollection<ProgramMemberEF> programMembers)
        {
            ProgramCode = programCode;
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
            ProgramMembers = programMembers;
        }

        [Key]
        [MaxLength(10)]
        public string ProgramCode { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string Target { get; set; }

        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

        public ICollection<ProgramMemberEF> ProgramMembers { get; set; }
    }

}
