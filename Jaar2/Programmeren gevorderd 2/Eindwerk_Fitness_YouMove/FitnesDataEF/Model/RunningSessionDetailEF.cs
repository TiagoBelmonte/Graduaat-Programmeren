using System.ComponentModel.DataAnnotations.Schema;

namespace FitnesDataEF.Model
{
    public class RunningSessionDetailEF
    {
        public RunningSessionDetailEF()
        {
        }

        public RunningSessionDetailEF(int seqNr, int runningSessionId, int intervalTime, float intervalSpeed)
        {
            seq_nr = seqNr;
            runningsession_id = runningSessionId;
            interval_time = intervalTime;
            interval_speed = intervalSpeed;
        }

        public int seq_nr { get; set; }

        public int runningsession_id { get; set; }

        public int interval_time { get; set; }

        public float interval_speed { get; set; }

        [ForeignKey(nameof(runningsession_id))]
        public RunningSessionMainEF runningsession { get; set; }
    }
}
