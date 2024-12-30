using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapTimeSlot
    {
        public static Time_slot MapToDomain(TimeSlotEF db)
        {
            try
            {
                return new Time_slot(db.time_slot_id,db.start_time,db.end_time,db.part_of_day);
            }
            catch (Exception)
            {

                throw new Exception("MapEquipment - mapToDomain");
            }

        }

        public static TimeSlotEF mapToDB(Time_slot TS)
        {
            try
            {
                return new TimeSlotEF(TS.time_slot_id,TS.start_time,TS.end_time,TS.part_of_day);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Equipment E model to EquipmentEF.", ex);
            }
        }
    }
}
