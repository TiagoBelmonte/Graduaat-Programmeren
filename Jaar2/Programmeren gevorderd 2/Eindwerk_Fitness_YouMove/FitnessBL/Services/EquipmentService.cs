using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class EquipmentService
    {
        private IEquipmentRepo repo;

        public EquipmentService(IEquipmentRepo repo)
        {
            this.repo = repo;
        }


        public Equipment AddEquipment(Equipment equipment)
        {
            try
            {
                return repo.addEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception("AddEquipment");
            }
        }

        public void updateEquipment(Equipment equipment)
        {
            try
            {
                repo.updateEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateEquipment");
            }
        }
    }
}
