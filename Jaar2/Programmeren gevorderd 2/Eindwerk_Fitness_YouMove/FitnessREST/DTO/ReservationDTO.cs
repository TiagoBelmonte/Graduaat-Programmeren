using FitnessBL.Model;
using System.Text.Json.Serialization;

namespace FitnessREST.DTO
{
    public class ReservationDTO
    {
        public int? ReservationId { get; set; }
        public Member Member { get; set; }
        public DateTime Date { get; set; }
        // Originele dictionary
        [JsonIgnore] // Verberg dit veld bij serialisatie
        public Dictionary<Time_slot, Equipment> TimeSlotEquipment { get; set; }

        // JSON-vriendelijke representatie
        public Dictionary<string, Equipment> TimeSlotEquipmentFormatted
        {
            get
            {
                return TimeSlotEquipment?
                    .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
            }
        }
    }
}
