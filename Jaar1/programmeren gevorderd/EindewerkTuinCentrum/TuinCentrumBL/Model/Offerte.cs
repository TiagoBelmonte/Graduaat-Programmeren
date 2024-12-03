using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TuinCentrumBL.Model
{
    public class Offerte
    {
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new DomeinException($"Product.Id - {value}");
                id = value;
            }
        }

        private DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (value > DateTime.Now)
                    throw new DomeinException($"Offerte.Datum - {value}");
                datum = value;
            }
        }

        private int Klantnummer;
        public int klantnummer
        {
            get { return Klantnummer; }
            set
            {
                if (value == null)
                    throw new DomeinException($"Offerte.Klant - {value}");
                Klantnummer = value;
            }
        }


        private int aantalProducten;
        public int AantalProducten
        {
            get { return aantalProducten; }
            set
            {
                if (value < 0)
                    throw new DomeinException($"Offerte.AantalProducten - {value}");
                aantalProducten = value;
            }
        }

        public bool afhaal { get; set; }
        //Aanleg(true wil zeggen dat de leverancier niet enkel de bestelling komt brengen, maar ook de aanleg van de tuin zal doen)
        //1 = true , 0 = false
        public bool aanleg { get; set; }
        //Aantal producten in de bestelling
        //1 = true , 0 = false
        private int aantal;
        public int Aantal
        {
            get { return aantal; }
            set
            {
                if (value < 0)
                    throw new DomeinException($"Offerte.AantalProducten - {value}");
                aantal = value;
            }
        }

        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }
        public Dictionary<int,int> Producten { get; set; }

        public Offerte(int Id, DateTime date, int klant, bool af, bool aan, int aantal, double prijs)
        {
            ID = Id;
            Datum = date;
            klantnummer = klant;
            afhaal = af;
            aanleg = aan;
            Aantal = aantal;
            Prijs = prijs;
            Producten = new Dictionary<int,int>();
        }

        public Offerte(int Id, DateTime date, int klant, bool af, bool aan, int aantal, double prijs, Dictionary<int,int> producten)
        {
            ID = Id;
            Datum = date;
            klantnummer = klant;
            afhaal = af;
            aanleg = aan;
            Aantal = aantal;
            Prijs = prijs;
            Producten = producten;
        }
        public Offerte()
        { 
        }
        public void voegProductToe(int product, int aantal)
        {
            if (aantal == 0 || product == null)
            {
                throw new DomeinException($"Offerte.VoegProductToe");
            }
            else
            {
                if (Producten.ContainsKey(product))
                {
                    throw new DomeinException("het product is al aanwezig in de offerte");
                }
                else
                {
                    Producten.Add(product,aantal);
                }
            }
        }

        public void verwijderProduct(int aantal, int productID)
        {

            if (aantal == 0 || productID == null)
            {
                throw new DomeinException($"Offerte.VoegProductToe");
            }
            else
            {
                if (!Producten.ContainsKey(productID))
                {
                    throw new DomeinException("het product is niet aanwezig in de offerte");
                }
                else
                {
                    Producten.Remove(productID);
                }
            }
        }
        public override string ToString()
        {
            return $"OfferteNummer: {ID}, Prijs: {Prijs} EUR";
        }
    }
}
