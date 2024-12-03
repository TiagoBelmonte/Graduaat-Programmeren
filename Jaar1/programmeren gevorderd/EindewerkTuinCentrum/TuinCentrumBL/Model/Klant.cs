using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;

namespace TuinCentrumBL.Model
{
    public class Klant
    {

        //id
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new DomeinException($"Klant.Id - {value}");
                id = value;
            }
        }
        //naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Klant_naam niet correct"); naam = value; }
        }
        //adres.
        private string adres;
        public string Adres
        {
            get { return adres; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Klant_naam niet correct"); adres = value; }
        }
        public Klant(int Id, string naam, string adres)
        { 
            ID = Id;
            Naam = naam;
            Adres = adres;
        }
        public Klant()
        {
        }
        public override string ToString()
        {
            return $"Naam: {Naam}, Adres: {Adres}";
        }

    }
}
