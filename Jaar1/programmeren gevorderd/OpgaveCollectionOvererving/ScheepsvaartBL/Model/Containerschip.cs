using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Containerschip : Vrachtship
    {
        private int aantalContainers;

        public int AantalContainers
        {
            get { return aantalContainers; }
            set { if (value < 0) throw new DomeinException("Containerschip_AantalContainers niet correct"); aantalContainers = value; }
        }

        public Containerschip(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, int aantalContainers)
            : base(naam, lengte, breedte, tonnage, cargowaarde)
        {
            AantalContainers = aantalContainers;
        }

    }
}
