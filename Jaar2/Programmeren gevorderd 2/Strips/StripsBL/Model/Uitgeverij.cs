using StripsBL.Exceptions;

namespace StripsBL.Model
{
    public class Uitgeverij
    {
        public int? Id { get; } // Alleen-lezen; wordt ingesteld door de database
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

        private string adres;
        public string Adres
        {
            get => adres;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("Adres mag niet leeg zijn.");
                }
                adres = value;
            }
        }

        public Uitgeverij(string naam, string adres)
        {
            Naam = naam;
            Adres = adres;
        }

        public override string ToString()
        {
            return $"Uitgeverij: {Naam}, Adres: {Adres}, Id: {Id}";
        }
    }
}
