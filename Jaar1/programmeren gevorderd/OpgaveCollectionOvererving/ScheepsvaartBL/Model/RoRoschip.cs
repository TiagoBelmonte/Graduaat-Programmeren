using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class RoRoschip : Vrachtship
    {
        private int aantalAutos;

        public int AantalAutos
        {
            get { return aantalAutos; }
            set { if (value < 0) throw new DomeinException("RoRoschip_AantalAutos niet correct"); aantalAutos = value; }
        }

        private int aantalTrucks;

        public int AantalTrucks
        {
            get { return aantalTrucks; }
            set { if (value < 0) throw new DomeinException("RoRoschip_AantalTrucks niet correct"); aantalTrucks = value; }
        }

        public RoRoschip(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, int aantalAutos, int aantalTrucks) 
            : base(naam, lengte, breedte, tonnage, cargowaarde)
        {
            AantalAutos = aantalAutos;
            AantalTrucks = aantalTrucks;
        }
    }
}
