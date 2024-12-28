using FitnessBL.Model;

namespace FitnessREST.DTO
{
    public class ProgramDTO
    {
        public string programCode { get; set; }
        public string name { get; set; }
        public string target { get; set; }
        public DateTime startDate { get; set; }
        public int max_members { get; set; }
        public List<Member> Members { get; set; }
    }
}
