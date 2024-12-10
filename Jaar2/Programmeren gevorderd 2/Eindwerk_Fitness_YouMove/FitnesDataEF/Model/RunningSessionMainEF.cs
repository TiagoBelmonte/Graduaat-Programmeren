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

        public RunningSessionMainEF(int runningSessionId, DateTime date, int memberId, int duration, float avgSpeed, MemberEF member, ICollection<RunningSessionDetailEF> runningSessionDetails)
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
            Member = member;
            RunningSessionDetails = runningSessionDetails;
        }

        [Key]
        public int RunningSessionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int Duration { get; set; }

        public float AvgSpeed { get; set; }

        [ForeignKey(nameof(MemberId))]
        public MemberEF Member { get; set; }

        public ICollection<RunningSessionDetailEF> RunningSessionDetails { get; set; }
    }

}
