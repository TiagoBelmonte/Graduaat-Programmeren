using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class CyclingSessionEF
    {
        public CyclingSessionEF()
        {
        }

        public CyclingSessionEF(int cyclingSessionId, DateTime date, int duration, int avgWatt, int maxWatt, int avgCadence, int maxCadence, string trainingType, string comment, int memberId, MemberEF member)
        {
            CyclingSessionId = cyclingSessionId;
            Date = date;
            Duration = duration;
            AvgWatt = avgWatt;
            MaxWatt = maxWatt;
            AvgCadence = avgCadence;
            MaxCadence = maxCadence;
            TrainingType = trainingType;
            Comment = comment;
            MemberId = memberId;
            Member = member;
        }

        [Key]
        public int CyclingSessionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int AvgWatt { get; set; }

        public int MaxWatt { get; set; }
        public int AvgCadence { get; set; }
        public int MaxCadence { get; set; }

        [MaxLength(45)]
        public string TrainingType { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public MemberEF Member { get; set; }
    }

}
