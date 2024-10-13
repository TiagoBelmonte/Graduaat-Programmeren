using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Passagiersschip : Schip
    {
        private int passagiers;

        public int Passagiers
        { 
            get { return passagiers; }
            set { if (value < 0) throw new DomeinException("Passagiersschip_Passagiers niet correct"); passagiers = value; }
        }
        public Passagiersschip(string naam, double lengte, double breedte, double tonnage, int passagiers) 
            : base(naam, lengte, breedte, tonnage)
        {
            Passagiers = passagiers;
        }


    }
}
