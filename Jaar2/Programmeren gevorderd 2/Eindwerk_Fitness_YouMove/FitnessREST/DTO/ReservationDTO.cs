using FitnessBL.Model;
using System.Text.Json.Serialization;

namespace FitnessREST.DTO
{
    public class ReservationDTO
    {
        public int MemberId { get; set; } // Alleen het ID van de member
        public DateTime Date { get; set; } // Datum van de reservatie

        // Originele dictionary
        [JsonIgnore] // Verberg dit veld bij serialisatie
        public Dictionary<int, int> TimeSlotEquipment { get; set; } // TimeslotID -> EquipmentID mapping

        // JSON-vriendelijke representatie (voor output en input)
        public List<TimeSlotEquipmentDTO> TimeSlotEquipmentFormatted
        {
            get
            {
                return TimeSlotEquipment?.Select(kvp => new TimeSlotEquipmentDTO
                {
                    TimeSlotId = kvp.Key,
                    EquipmentId = kvp.Value
                }).ToList();
            }
            set
            {
                if (value != null)
                {
                    TimeSlotEquipment = value.ToDictionary(tse => tse.TimeSlotId, tse => tse.EquipmentId);
                }
            }
        }
    }

    public class TimeSlotEquipmentDTO
    {
        public int TimeSlotId { get; set; } // ID van de timeslot
        public int EquipmentId { get; set; } // ID van de equipment
    }

}
