using ScheepsvaartBL.Exceptions;
using ScheepvaartBL.Exceptions;
using ScheepvaartBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Schip
    {
        private Vloot vloot;
        public Vloot Vloot
        {
            get { return vloot; }
            set { if (value == null) throw new VlootException("vloot mag niet null zijn"); vloot = value; }
        }

        private string naam;
        public string Naam
        {
            get { return naam; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Sleepboot_Naam niet correct"); naam = value; }
        }

        private double lengte;
        public double Lengte
        {
            get { return lengte; }
            set { if (value <= 0) throw new DomeinException("Sleepboot_Lengte niet correct"); lengte = value; }
        }

        private double breedte;
        public double Breedte
        {
            get { return breedte; }
            set { if (value <= 0) throw new DomeinException("Sleepboot_Breedte niet correct"); breedte = value; }
        }

        private double tonnage;
        public double Tonnage
        {
            get { return tonnage; }
            set { if (value <= 0) throw new DomeinException("Sleepboot_Tonnage niet correct"); tonnage = value; }
        }

        public Schip(string naam, double lengte, double breedte, double tonnage)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            Tonnage = tonnage;
        }
    }
}
