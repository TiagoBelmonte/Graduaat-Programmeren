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
        public int TimeSlotId { get; set; }

        [Required]
        public int StartTime { get; set; }

        [Required]
        public int EndTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string PartOfDay { get; set; }

        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
