namespace FitnessREST.DTO
{
    public class ReservationDTO
    {
        public int reservation_id { get; set; }
        public int equipment_id { get; set; }
        public int time_slot_id { get; set; }
        public DateTime date { get; set; }
        public int member_id { get; set; }
    }
}
