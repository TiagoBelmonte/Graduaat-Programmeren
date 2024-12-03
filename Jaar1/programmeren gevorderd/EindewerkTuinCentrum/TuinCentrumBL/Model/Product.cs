using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;

namespace TuinCentrumBL.Model
{
    public class Product
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

        private string nedelandseNaam;
        public string NederlandseNaam
        {
            get { return nedelandseNaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException($"Product.nedelandseNaam - {value}");
                nedelandseNaam = value;
            }
        }

        private string wetenschappelijkeNaam;
        public string WetenschappelijkeNaam
        {
            get { return wetenschappelijkeNaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException($"Product.wetenschappelijkeNaam - {value}");
                wetenschappelijkeNaam = value;
            }
        }

        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set
            {
                if (value <= 0)
                    throw new DomeinException($"Product.prijs - {value}");
                prijs = value;
            }
        }

        private string beschrijving;
        public string Beschrijving
        {
            get { return beschrijving; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException($"Product.Beschrijving - {value}");
                beschrijving = value;
            }
        }

        public Product(int Id, string nedNaam, string wetNaam, double prijs, string beschrijving)
        { 
            ID = Id;
            NederlandseNaam = nedNaam;
            WetenschappelijkeNaam= wetNaam;
            Prijs = prijs;
            Beschrijving= beschrijving;
        }
        public Product()
        { 
        }
        public override string ToString()
        {
            return $"{WetenschappelijkeNaam}, Prijs: {Prijs} EUR";
        }
    }
}
