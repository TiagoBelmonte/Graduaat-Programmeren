using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class RunningSessionDetailEF
    {
        public RunningSessionDetailEF()
        {
        }

        public RunningSessionDetailEF(int seqNr, int runningSessionId, int intervalTime, float intervalSpeed, RunningSessionMainEF runningSession)
        {
            SeqNr = seqNr;
            RunningSessionId = runningSessionId;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
            RunningSession = runningSession;
        }

        [Key]
        public int SeqNr { get; set; }

        [Required]
        public int RunningSessionId { get; set; }

        [Required]
        public int IntervalTime { get; set; }

        public float IntervalSpeed { get; set; }

        [ForeignKey(nameof(RunningSessionId))]
        public RunningSessionMainEF RunningSession { get; set; }
    }

}
