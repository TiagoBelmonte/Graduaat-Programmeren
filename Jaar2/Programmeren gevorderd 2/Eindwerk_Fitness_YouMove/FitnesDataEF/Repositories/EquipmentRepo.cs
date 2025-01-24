using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using Microsoft.EntityFrameworkCore;
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


        public Equipment GetEquipment(int id)
        {


            return MapEquipment.MapToDomain(ctx.equipment.Where(x => x.equipment_id == id).AsNoTracking().FirstOrDefault());

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
                SaveAndClear();
            }
            catch (Exception)
            {

                throw new Exception("EquipmentRepo - updateEquipment");
            }
        }

        public Equipment GetEquipmentId(int id)
        {
            try
            {
                EquipmentEF equipmentEF = ctx
                    .equipment.Where(x => x.equipment_id == id)
                    .AsNoTracking()
                    .FirstOrDefault();

                if (equipmentEF == null)
                {
                    return null;
                }
                else
                {
                    return MapEquipment.MapToDomain(equipmentEF);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EquipmentRepo - GetEquipomentId", ex);
            }
        }
    }
}
