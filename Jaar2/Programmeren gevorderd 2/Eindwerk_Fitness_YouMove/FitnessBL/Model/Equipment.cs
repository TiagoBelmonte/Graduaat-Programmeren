using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Equipment
    {

        public int? equipment_id { get; set; }
        public string device_type { get; set; }
        public bool maintenance { get; set; }

        public Equipment(int? id, string device, bool main)
        {
            equipment_id = id;
            device_type = device;
            maintenance = main;
        }
    }
}
