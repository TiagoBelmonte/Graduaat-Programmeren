using FitnessBL.Exceptions;
using System;

namespace FitnessBL.Model
{
    public class Reservatie
    {
        private Klant klant;
        private DateTime datum;
        private int? Id;
        private List<Tijdslot> tijdslots;

        // Constructor
        public Reservatie(Klant klant, DateTime datum, List<Tijdslot> tijdslots)
        {
            Klant = klant; // Valideert de klant via de eigenschap
            Datum = datum; // Valideert de startdatum via de eigenschap
            this.tijdslots = tijdslots;
        }

        public Reservatie(int? id, List<Tijdslot> tijdslots, Klant klant, DateTime datum)
        {
            Id = id;
            this.tijdslots = tijdslots;
            Klant = klant;
            Datum = datum;
        }

        // Klant eigenschap
        public Klant Klant
        {
            get { return klant; }
            set
            {
                if (value == null)
                {
                    throw new DomeinExceptions("U moet een klant meegeven die al bestaat.");
                }
                klant = value;
            }
        }

        // Startdatum eigenschap
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (value > DateTime.Now.AddDays(7))
                {
                    throw new DomeinExceptions("Reservatie kan maar max 1 week op voorhand.");
                }
                datum = value;
            }
        }
        public void voegTijdSlotToe(Tijdslot tijdslot)
        {
            if (tijdslots.Count == 2)
            {
                throw new DomeinExceptions("Je kan maximaal 2 tijdsloten na elkaar reserveren");
            }
            else
            {
                if (tijdslots.Contains(tijdslot))
                {
                    throw new DomeinExceptions("Dit Tijdslot is al reeds toegevoegd!");
                }
                else
                {
                    if (tijdslots.Count != 0 && (tijdslot.Id + 1 != tijdslots[0].Id && tijdslot.Id - 1 != tijdslots[0].Id))
                    {
                        throw new DomeinExceptions("Je kan enkel 2 tijdsloten reserveren die na elkaar komen");
                    }
                    else
                    {
                        tijdslots.Add(tijdslot);
                    }
                }
            }
        }

    }
}
