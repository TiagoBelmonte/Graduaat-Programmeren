using FitnessBL.Model;

namespace FitnessREST.DTO
{
    public class RunningSession_mainDTO
    {
        public int? runningSession_id { get; set; }
        public DateTime date { get; set; }
        //public Member member { get; set; }
        public int member_id { get; set; }
        public int duration { get; set; }
        public int avg_speed { get; set; }
    }
}
