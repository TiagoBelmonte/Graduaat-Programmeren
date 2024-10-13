using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Vrachtship : Schip
    {
        private Decimal cargowaarde;

        public Decimal Cargowaarde
        {
            get { return cargowaarde; }
            set { if (value < 0 ) throw new DomeinException("Vrachtschip_Cargowaarde niet correct"); cargowaarde = value; }
        }

        public Vrachtship(string naam, double lengte, double breedte, double tonnage, Decimal cargowaarde) : base(naam, lengte, breedte, tonnage)
        {
            Cargowaarde = cargowaarde;
        }
  
    }
}
