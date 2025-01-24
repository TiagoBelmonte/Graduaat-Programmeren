using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IEquipmentRepo
    {
        Equipment addEquipment(Equipment equipment);
        Equipment GetEquipment(int id);
        Equipment GetEquipmentId(int id);
        void updateEquipment(Equipment equipment);
    }
}
