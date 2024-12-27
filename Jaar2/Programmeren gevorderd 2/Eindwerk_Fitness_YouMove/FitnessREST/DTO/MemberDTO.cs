using FitnessBL.Enum;

namespace FitnessREST.DTO
{
    public class MemberDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public int? member_id { get; set; }
        public List<string> interests { get;set; }
        public KlantType memberType { get; set; }
    }
}
