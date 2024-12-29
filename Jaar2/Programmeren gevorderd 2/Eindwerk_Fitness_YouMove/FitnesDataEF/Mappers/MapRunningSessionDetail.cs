using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapRunningSessionDetail
    {
        public static Runningsession_detail MapToDomain(RunningSessionDetailEF db)
        {
            try
            {
                return new Runningsession_detail
                {
                    seq_nr = db.seq_nr,
                    runningsession_id = db.runningsession_id,
                    interval_time = db.interval_time,
                    interval_speed = (decimal)db.interval_speed,
                };
            }
            catch (Exception)
            {
                throw new Exception("MapEquipment - mapToDomain");
            }
        }

        public static RunningSessionDetailEF mapToDB(Runningsession_detail RD)
        {
            try
            {
                return new RunningSessionDetailEF
                {
                    seq_nr = (int)RD.seq_nr,
                    runningsession_id = RD.runningsession_id,
                    interval_time = RD.interval_time,
                    interval_speed = (float)RD.interval_speed
                };

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping RunningSessionMain E model to EquipmentEF.", ex);
            }
        }
    }
}
