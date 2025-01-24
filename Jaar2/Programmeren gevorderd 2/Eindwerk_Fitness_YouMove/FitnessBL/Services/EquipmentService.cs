using FitnessBL.Exceptions;
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

        public Equipment GetEquipmentId(int id)
        {
            Equipment equipment = repo.GetEquipmentId(id);
            if (equipment == null)
                throw new ServiceException(
                    "EquipmentService - GetEquipmentId - Er is geen equipment met dit id!"
                );
            return equipment;
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

        public void updateEquipment(int id)
        {
            try
            {
                Equipment equipment = repo.GetEquipment(id);
                equipment.maintenance = true;
                repo.updateEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateEquipment");
            }
        }

    }
}
