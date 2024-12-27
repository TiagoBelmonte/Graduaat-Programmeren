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

        public MemberEF(int? memberId, string firstName, string lastName, string Email, string Address, DateTime Birthday, string Interests, string memberType, ICollection<ReservationEF> reservations, ICollection<RunningSessionMainEF> runningSessions, ICollection<CyclingSessionEF> cyclingSessions, ICollection<ProgramMemberEF> programMembers)
        {
            member_id = memberId;
            first_name = firstName;
            last_name = lastName;
            email = Email;
            address = Address;
            birthday = Birthday;
            interests = Interests;
            membertype = memberType;
            reservation = reservations;
            runningsession = runningSessions;
            cyclingsession = cyclingSessions;
            programmembers = programMembers;
        }

        [Key]
        public int? member_id { get; set; }

        [Required]
        [MaxLength(45)]
        public string first_name { get; set; }

        [Required]
        [MaxLength(45)]
        public string last_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? email { get; set; }

        [MaxLength(200)]
        public string address { get; set; }

        public DateTime birthday { get; set; }

        [MaxLength(500)]
        public string? interests { get; set; }
        [MaxLength(20)]
        public string? membertype { get; set; }

        public ICollection<ReservationEF> reservation { get; set; }
        public ICollection<RunningSessionMainEF> runningsession { get; set; }
        public ICollection<CyclingSessionEF> cyclingsession { get; set; }
        public ICollection<ProgramMemberEF> programmembers { get; set; }
    }

}
