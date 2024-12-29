using FitnessBL.Model;

namespace FitnessREST.DTO
{
    public class RunningSession_detailDTO
    {
        public int seq_nr { get; set; }
        //public Runningsession_main runningsession { get; set; }
        public int runningsession_id { get; set; }
        public int interval_time { get; set; }
        public decimal interval_speed { get; set; }
    }
}
