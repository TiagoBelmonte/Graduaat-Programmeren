using FitnessBL.Exceptions;
using System;

namespace FitnessBL.Model
{
    public class Reservatie
    {
        private Klant klant;
        private DateTime startdatum;

        // Constructor
        public Reservatie(Klant klant, DateTime startdatum)
        {
            Klant = klant; // Valideert de klant via de eigenschap
            Startdatum = startdatum; // Valideert de startdatum via de eigenschap
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
        public DateTime Startdatum
        {
            get { return startdatum; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new DomeinExceptions("Startdatum kan niet in het verleden liggen.");
                }
                if (value > DateTime.Now.AddDays(7))
                {
                    throw new DomeinExceptions("Toestel reserveren kan maar 1 week op voorhand.");
                }
                startdatum = value;
            }
        }
    }
}
