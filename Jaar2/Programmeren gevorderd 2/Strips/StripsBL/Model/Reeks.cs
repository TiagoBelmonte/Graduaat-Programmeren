using StripsBL.Exceptions;
using System.Collections.Generic;

namespace StripsBL.Model
{
    public class Reeks
    {
        private string naam;
        public string Naam
        {
            get => naam;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("Naam mag niet leeg zijn.");
                }
                naam = value;
            }
        }

        private List<Strip> strips;
        public IReadOnlyList<Strip> Strips => strips.AsReadOnly();

        public Reeks(string naam)
        {
            Naam = naam;
            strips = new List<Strip>();
        }

        public void VoegStripToe(Strip strip)
        {
            if (strip == null)
            {
                throw new DomeinException("Strip mag niet null zijn.");
            }

            if (strips.Contains(strip))
            {
                throw new DomeinException("Deze strip is al toegevoegd aan de reeks.");
            }

            strips.Add(strip);
        }

        public void VerwijderStrip(Strip strip)
        {
            if (strip == null || !strips.Contains(strip))
            {
                throw new DomeinException("Deze strip zit niet in de reeks en kan niet verwijderd worden.");
            }

            strips.Remove(strip);
        }
    }
}
