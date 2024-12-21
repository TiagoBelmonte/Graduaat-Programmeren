using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class EquipmentEF
    {
        [Key]
        public int equipment_id { get; set; }

        [Required]
        [MaxLength(45)]
        public string device_type { get; set; }

        public ICollection<ReservationEF> reservation { get; set; }
    }

}
