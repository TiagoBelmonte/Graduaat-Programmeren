using FitnessBL.Enum;
using FitnessBL.Model;

namespace FitnessREST.DTO
{
    public class CyclingSessionDTO
    {
        public int cyclingsession_id { get; set; }
        public DateTime date { get; set; }
        public int duration { get; set; }
        public int avg_watt { get; set; }
        public int max_watt { get; set; }
        public int avg_cadence { get; set; }
        public int max_cadence { get; set; }
        public Trainingtype trainingtype { get; set; } // Enum in plaats van string
        public string? comment { get; set; }
        //public Member member { get; set; }
        public int memberID { get; set; }
    }
}
