using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Reservation
    {
        private Member member;
        private DateTime date;
        private int? reservation_id;
        private List<Time_slot> time_slots;

        public Reservation(int? id, List<Time_slot> time_slots, Member member, DateTime date)
        {
            reservation_id = id;
            this.time_slots = time_slots;
            Member = member;
            Date = date;
        }

        // Member eigenschap
        public Member Member
        {
            get { return member; }
            set
            {
                if (value == null)
                {
                    throw new DomeinExceptions("U moet een member meegeven die al bestaat.");
                }
                member = value;
            }
        }

        // Startdatum eigenschap
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value > DateTime.Now.AddDays(7))
                {
                    throw new DomeinExceptions("Reservatie kan maar max 1 week op voorhand.");
                }
                date = value;
            }
        }
        public void voegTijdSlotToe(Time_slot tijdslot)
        {
            if (time_slots.Count == 2)
            {
                throw new DomeinExceptions("Je kan maximaal 2 tijdsloten na elkaar reserveren");
            }
            else
            {
                if (time_slots.Contains(tijdslot))
                {
                    throw new DomeinExceptions("Dit Time_slot is al reeds toegevoegd!");
                }
                else
                {
                    if (time_slots.Count != 0 && (tijdslot.time_slot_id + 1 != time_slots[0].time_slot_id && tijdslot.time_slot_id - 1 != time_slots[0].time_slot_id))
                    {
                        throw new DomeinExceptions("Je kan enkel 2 tijdsloten reserveren die na elkaar komen");
                    }
                    else
                    {
                        time_slots.Add(tijdslot);
                    }
                }
            }
        }
    }
}
