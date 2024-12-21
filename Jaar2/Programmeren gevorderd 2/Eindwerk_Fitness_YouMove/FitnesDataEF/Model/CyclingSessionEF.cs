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

        public CyclingSessionEF(int cyclingSessionId, DateTime Date, int Duration, int avgWatt, int maxWatt, int avgCadence, int maxCadence, string trainingType, string Comment, int memberId, MemberEF member)
        {
            cyclingSession_id = cyclingSessionId;
            date = Date;
            duration = Duration;
            avg_watt = avgWatt;
            max_watt = maxWatt;
            avg_cadence = avgCadence;
            max_cadence = maxCadence;
            trainingtype = trainingType;
            comment = comment;
            member_id = memberId;
            members = member;
        }

        [Key]
        public int cyclingSession_id { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int duration { get; set; }

        [Required]
        public int avg_watt { get; set; }

        public int max_watt { get; set; }
        public int avg_cadence { get; set; }
        public int max_cadence { get; set; }

        [MaxLength(45)]
        public string trainingtype { get; set; }

        [MaxLength(500)]
        public string? comment { get; set; }

        [Required]
        public int member_id { get; set; }

        [ForeignKey(nameof(member_id))]
        public MemberEF members { get; set; }
    }

}
