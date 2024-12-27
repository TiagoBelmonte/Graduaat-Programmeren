using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapEquipment
    {
        public static Equipment MapToDomain(EquipmentEF db)
        {
            try
            {
                return new Equipment(db.equipment_id, db.device_type, db.maintenance);
            }
            catch (Exception)
            {

                throw new Exception("MapEquipment - mapToDomain");
            }

        }

        public static EquipmentEF mapToDB(Equipment E)
        {
            try
            {
                return new EquipmentEF(E.equipment_id, E.device_type, E.maintenance);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Equipment E model to EquipmentEF.", ex);
            }
        }

    }
}
