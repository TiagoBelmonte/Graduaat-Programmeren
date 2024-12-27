using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Repositories
{
    public class EquipmentRepo : IEquipmentRepo
    {
        private FitnessContext ctx;

        public EquipmentRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public Equipment addEquipment(Equipment equipment)
        {
            try
            {
                EquipmentEF e = MapEquipment.mapToDB(equipment);
                ctx.equipment.Add(e);
                SaveAndClear();
                equipment.equipment_id = e.equipment_id;
                return equipment;
                
            }
            catch (Exception)
            {

                throw new Exception("EquipmentRepo - AddEquipment");
            }
        }

        public void updateEquipment(Equipment equipment)
        {
            try
            {
                ctx.equipment.Update(MapEquipment.mapToDB(equipment));
            }
            catch (Exception)
            {

                throw new Exception("EquipmentRepo - updateEquipment");
            }
        }
    }
}
