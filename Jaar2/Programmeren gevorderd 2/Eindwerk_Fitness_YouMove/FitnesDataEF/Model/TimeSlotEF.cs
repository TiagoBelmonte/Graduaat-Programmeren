using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class TimeSlotEF
    {
        [Key]
        public int time_slot_id { get; set; }

        [Required]
        public int start_time { get; set; }

        [Required]
        public int end_time { get; set; }

        [Required]
        [MaxLength(20)]
        public string part_of_day { get; set; }

        public ICollection<ReservationEF> reservation { get; set; }
    }

}
