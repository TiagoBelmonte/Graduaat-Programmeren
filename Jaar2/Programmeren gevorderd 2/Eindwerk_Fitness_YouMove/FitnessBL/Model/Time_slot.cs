using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Time_slot
    {
        // Eigenschappen
        public int time_slot_id { get; set; }
        public int start_time { get; set; }
        public int end_time { get; set; }
        public string part_of_day { get; set; }

        // Constructor
        public Time_slot(int id, int startUur, int eindUur, string dagDeel)
        {
            time_slot_id = id;
            start_time = startUur;
            end_time = eindUur;
            part_of_day = dagDeel;
        }

        // Optionele override van ToString() om het tijdslot gemakkelijk te tonen
        public override string ToString()
        {
            return $"Tijdslot {time_slot_id}: {start_time}:00 - {end_time}:00 ({part_of_day})";
        }
    }
}
