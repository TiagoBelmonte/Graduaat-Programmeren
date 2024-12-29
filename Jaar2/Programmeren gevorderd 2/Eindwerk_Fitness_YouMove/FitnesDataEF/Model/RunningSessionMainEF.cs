using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class RunningSessionMainEF
    {
        public RunningSessionMainEF()
        {
        }

        public RunningSessionMainEF(int runningSessionId, DateTime Date, int memberId, int Duration, int avgSpeed, MemberEF member, ICollection<RunningSessionDetailEF> RunningSessionDetails)
        {
            runningSession_id = runningSessionId;
            date = Date;
            member_id = memberId;
            duration = Duration;
            avg_speed = avgSpeed;
            members = member;
            runningsessiondetail = RunningSessionDetails;
        }

        [Key]
        public int runningSession_id { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int member_id { get; set; }

        [Required]
        public int duration { get; set; }

        public int avg_speed { get; set; }

        [ForeignKey(nameof(member_id))]
        public MemberEF members { get; set; }

        public ICollection<RunningSessionDetailEF> runningsessiondetail { get; set; }
    }

}
