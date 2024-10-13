using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Tanker : Vrachtship
    {
        private double volume;

        public double Volume
        {
            get { return volume; }
            set { if (value < 0) throw new DomeinException("Tanker_Volume niet correct"); volume = value; }
        }
        public Tanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume) 
            : base(naam, lengte, breedte, tonnage, cargowaarde)
        {
            Volume = volume;
        }
    }
}
