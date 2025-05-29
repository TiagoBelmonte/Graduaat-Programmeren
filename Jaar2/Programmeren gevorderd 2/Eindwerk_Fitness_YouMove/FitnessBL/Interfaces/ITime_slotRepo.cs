using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface ITime_slotRepo
    {
        IEnumerable<Time_slot> GetTimeSlots();
        Time_slot GetTime_slotId(int id);
    }
}
