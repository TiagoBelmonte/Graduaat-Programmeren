using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
    public class Reservation
    {
        public int Reservation_id { get; set; }
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public Dictionary<Time_slot, Equipment> TimeslotEquipment =
            new Dictionary<Time_slot, Equipment>();


        public List<object> TimeslotEquipmentSerialized
        {
            get
            {
                return TimeslotEquipment
                    .Select(kvp => new { TimeSlot = kvp.Key, Equipment = kvp.Value })
                    .ToList<object>();
            }
        }
    }
}
