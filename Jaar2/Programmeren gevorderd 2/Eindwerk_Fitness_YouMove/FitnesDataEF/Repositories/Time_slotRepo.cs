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
    public class Time_slotRepo : ITime_slotRepo
    {
        private FitnessContext ctx;

        public Time_slotRepo(string connectionString)
        {
            ctx = new FitnessContext(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public IEnumerable<Time_slot> GetTimeSlots()
        {
            try
            {
                IEnumerable<TimeSlotEF> tsEFs = ctx.time_slot.Select(x => x).ToList();

                List<Time_slot> timeSlots = new List<Time_slot>();
                foreach (TimeSlotEF tsEF in tsEFs)
                {
                    Time_slot ts = MapTimeSlot.MapToDomain(tsEF);
                    timeSlots.Add(ts);
                }

                return timeSlots;
            }
            catch (Exception ex)
            {
                throw new Exception("Time_slotRepo - GetTimeSlots");
            }
        }

        public Time_slot GetTime_slotId(int id)
        {
            try
            {
                TimeSlotEF time_slotEF = ctx
                    .time_slot.Where(x => x.time_slot_id == id)
                    .AsNoTracking()
                    .FirstOrDefault();

                if (time_slotEF == null)
                {
                    return null;
                }
                else
                {
                    return MapTimeSlot.MapToDomain(time_slotEF);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Time_slotRepo - GetTime_slotId", ex);
            }
        }
    }
}

