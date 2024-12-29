using FitnesDataEF.Model;
using FitnessBL.Enum;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapRunningSessionMain
    {
        public static Runningsession_main MapToDomain(RunningSessionMainEF db)
        {
            try
            {
                return new Runningsession_main
                {
                    runningSession_id = db.runningSession_id,
                    date = db.date,
                    member_id = db.member_id,
                    duration = db.duration,
                    avg_speed = (int)db.avg_speed // Fixing the conversion from float to int
                };
            }
            catch (Exception)
            {
                throw new Exception("MapEquipment - mapToDomain");
            }
        }

        public static RunningSessionMainEF mapToDB(Runningsession_main RM)
        {
            try
            {
                return new RunningSessionMainEF
                {
                    runningSession_id = (int)RM.runningSession_id,
                    date = RM.date,
                    member_id = RM.member_id,
                    duration = RM.duration,
                    avg_speed = RM.avg_speed
                };

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping RunningSessionMain E model to EquipmentEF.", ex);
            }
        }
    }
}
