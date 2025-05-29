using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
    public class Equipment
    {
        public int Equipment_id { get; set; }
        public string Device_type { get; set; }
        public bool maintenance { get; set; }

        public override string? ToString()
        {
            return $"EquipmentId: {Equipment_id}, Device type: {Device_type}";
        }

    }
}
