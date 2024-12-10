using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class MemberEF
    {
        public MemberEF()
        {
        }

        public MemberEF(int memberId, string firstName, string lastName, string email, string address, DateTime birthday, string interests, string memberType, ICollection<ReservationEF> reservations, ICollection<RunningSessionMainEF> runningSessions, ICollection<CyclingSessionEF> cyclingSessions, ICollection<ProgramMemberEF> programMembers)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            MemberType = memberType;
            Reservations = reservations;
            RunningSessions = runningSessions;
            CyclingSessions = cyclingSessions;
            ProgramMembers = programMembers;
        }

        [Key]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(45)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(45)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(500)]
        public string Interests { get; set; }
        [MaxLength(20)]
        public string MemberType { get; set; }

        public ICollection<ReservationEF> Reservations { get; set; }
        public ICollection<RunningSessionMainEF> RunningSessions { get; set; }
        public ICollection<CyclingSessionEF> CyclingSessions { get; set; }
        public ICollection<ProgramMemberEF> ProgramMembers { get; set; }
    }

}
