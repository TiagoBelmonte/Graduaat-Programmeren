﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FitnessBL.Exceptions;
using Newtonsoft.Json;

namespace FitnessBL.Model
{
    public class Reservation
    {
        public int Reservation_id { get; set; }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value > DateTime.Now.AddDays(7))
                {
                    throw new ReservationException(
                        "Een reservatie kan maximaal 1 week op voorhand geplaatst worden!"
                    );
                }
                date = value;
            }
        }
        public Member Member { get; set; }

        
        public Dictionary<Time_slot, Equipment> TimeslotEquipment =
            new Dictionary<Time_slot, Equipment>();

        
        

        public Reservation() { }

        public Reservation(
            DateTime datum,
            Member klant,
            Dictionary<Time_slot, Equipment> timeslotEquipment
        )
        {
            Date = datum;
            Member = klant;
            TimeslotEquipment = timeslotEquipment;
        }

        public Reservation(
            int id,
            DateTime datum,
            Member klant,
            Dictionary<Time_slot, Equipment> timeslotEquipment
        )
        {
            Reservation_id = id;
            Date = datum;
            Member = klant;
            TimeslotEquipment = timeslotEquipment;
        }

        public void voegTijdSlotToe(Time_slot tijdslot, Equipment equipment)
        {
            if (TimeslotEquipment.Count == 2)
            {
                throw new ReservationException("Je kan maximaal 2 tijdsloten na elkaar reserveren");
            }
            else
            {
                if (TimeslotEquipment.Keys.Contains(tijdslot))
                {
                    throw new ReservationException("Dit Time_slot is al reeds toegevoegd!");
                }
                else
                {
                    if (
                        TimeslotEquipment.Count != 0
                        && (
                            tijdslot.Time_slot_id + 1
                                != TimeslotEquipment.Keys.ElementAt(0).Time_slot_id
                            && tijdslot.Time_slot_id - 1
                                != TimeslotEquipment.Keys.ElementAt(0).Time_slot_id
                        )
                    )
                    {
                        throw new ReservationException(
                            "Je tijdsloten moeten op elkaar volgen dus!"
                        );
                    }
                    else
                    {
                        TimeslotEquipment.Add(tijdslot, equipment);
                    }
                }
            }
        }

        public void verwijderTijdslot(Time_slot tijdslot)
        {
            if (!TimeslotEquipment.Keys.Contains(tijdslot))
            {
                throw new ReservationException(
                    "Dit tijdslot is niet gereserveerd door u dus kunt u hem niet verwijderen!"
                );
            }
            else
            {
                TimeslotEquipment.Remove(tijdslot);
            }
        }
    }
}
