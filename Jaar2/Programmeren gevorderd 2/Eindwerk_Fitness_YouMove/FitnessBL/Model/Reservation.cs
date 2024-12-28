using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;

namespace FitnessBL.Model
{
    public class Reservation
    {
        // Eigenschappen
        public int? ReservationId { get; set; }
        public Member Member { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Time_slot, Equipment> TimeSlotEquipment { get; set; }

        // Constructor
        public Reservation(int? reservationId, Dictionary<Time_slot, Equipment> timeSlotEquipment, Member member, DateTime date)
        {
            if (member == null)
            {
                throw new DomeinExceptions("U moet een member meegeven die al bestaat.");
            }

            if (date > DateTime.Now.AddDays(7))
            {
                throw new DomeinExceptions("Reservatie kan maar maximaal 1 week op voorhand.");
            }

            ReservationId = reservationId;
            TimeSlotEquipment = timeSlotEquipment ?? new Dictionary<Time_slot, Equipment>(); // Zorg ervoor dat TimeSlotEquipment nooit null is
            Member = member;
            Date = date;
        }

        // Methoden
        public void VoegTijdSlotToe(Time_slot tijdslot, Equipment equipment)
        {
            if (TimeSlotEquipment.Count == 2)
            {
                throw new DomeinExceptions("Je kan maximaal 2 tijdsloten na elkaar reserveren.");
            }

            if (TimeSlotEquipment.ContainsKey(tijdslot))
            {
                throw new DomeinExceptions("Dit Time_slot is al reeds toegevoegd!");
            }

            if (TimeSlotEquipment.Count != 0)
            {
                Time_slot existingSlot = new List<Time_slot>(TimeSlotEquipment.Keys)[0];
                if (tijdslot.time_slot_id + 1 != existingSlot.time_slot_id &&
                    tijdslot.time_slot_id - 1 != existingSlot.time_slot_id)
                {
                    throw new DomeinExceptions("Je kan enkel 2 tijdsloten reserveren die na elkaar komen.");
                }
            }

            TimeSlotEquipment.Add(tijdslot, equipment);
        }
    }
}
