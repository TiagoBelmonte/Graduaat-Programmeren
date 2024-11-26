using FitnessBL.Exceptions;
using System;

namespace FitnessBL.Model
{
    public class Toestel
    {
        // Dit Id wordt waarschijnlijk door de database gegenereerd en is read-only
        public int? Id { get; }

        // Private veld voor de beschrijving
        private string beschrijving;

        // Constructor
        public Toestel(string beschrijving)
        {
            Beschrijving = beschrijving; // De Beschrijving wordt gevalideerd door de setter
        }

        // Eigenschap voor de Beschrijving
        public string Beschrijving
        {
            get { return beschrijving; }
            set
            {
                // Valideer of de Beschrijving niet leeg of null is
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("Beschrijving van dit toestel mag niet leeg zijn.");
                }
                beschrijving = value; // Toewijzing aan het private veld
            }
        }
    }
}
