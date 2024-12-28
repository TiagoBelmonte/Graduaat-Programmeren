using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapReservation
    {
        public static Reservation MapToDomain(
            ReservationEF db,
            List<Time_slot> timeSlots,
            List<Equipment> equipments,
            List<Member> members
            )
        {
            try
            {
                // Maak een lege dictionary voor TimeSlotEquipment
                Dictionary<Time_slot,Equipment> timeSlotEquipment = new Dictionary<Time_slot, Equipment>();

                // Controleer of de time_slot_id en equipment_id in de database niet null zijn
                if (db.time_slot_id != null && db.equipment_id != null)
                {
                    // Zoek de bijbehorende Time_slot en Equipment
                    Time_slot timeSlot = timeSlots.FirstOrDefault(ts => ts.time_slot_id == db.time_slot_id);
                    Equipment equipment = equipments.FirstOrDefault(eq => eq.equipment_id == db.equipment_id);

                    if (timeSlot != null && equipment != null)
                    {
                        timeSlotEquipment.Add(timeSlot, equipment);
                    }
                }

                // Zoek de bijbehorende Member op basis van member_id
                Member member = members.FirstOrDefault(m => m.member_id == db.member_id);
                if (member == null)
                {
                    throw new Exception($"Member met ID {db.member_id} niet gevonden.");
                }

                // Maak een nieuwe Reservation met de gemapte waarden
                return new Reservation(
                    db.reservation_id,
                    timeSlotEquipment,
                    member,
                    db.date
                );
            }
            catch (Exception ex)
            {
                throw new Exception("MapReservation - mapToDomain", ex);
            }
        }



        public static List<ReservationEF> MapToDB(Reservation reservation)
        {
            try
            {
                List<ReservationEF> reservationEFList = new List<ReservationEF>();

                foreach (var pair in reservation.TimeSlotEquipment)
                {
                    // Creëer een nieuwe ReservationEF voor elke TimeSlot-Equipment combinatie
                    reservationEFList.Add(new ReservationEF
                    {
                        reservation_id = (int)reservation.ReservationId,
                        time_slot_id = pair.Key.time_slot_id,
                        equipment_id = (int)pair.Value.equipment_id,
                        member_id = (int)reservation.Member.member_id,
                        date = reservation.Date
                    });
            }

                return reservationEFList;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Reservation model to ReservationEF.", ex);
            }
        }

    }
}
