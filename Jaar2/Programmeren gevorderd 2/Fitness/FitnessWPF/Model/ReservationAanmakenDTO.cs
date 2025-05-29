using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
    public class ReservationAanmakenDTO
    {
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public List<TimeslotEquipmentDTO> EquipmentPerTimeslot { get; set; }
    }
}
