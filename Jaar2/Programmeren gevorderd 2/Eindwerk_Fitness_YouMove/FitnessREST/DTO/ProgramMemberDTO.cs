using FitnessBL.Model;

namespace FitnessREST.DTO
{
    public class ProgramMemberDTO
    {
        public Program programCode { get; set; }
        public Member member { get; set; }
    }
}
