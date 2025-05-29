using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
    public class Time_slot
    {
        public int Time_slot_id { get; set; }
        public int Start_time { get; set; }
        public int End_time { get; set; }

        public string Part_of_day { get; set; }

        public override string? ToString()
        {
            return $"Id: {Time_slot_id}, Hours: {Start_time} - {End_time}";
        }
    }
}
