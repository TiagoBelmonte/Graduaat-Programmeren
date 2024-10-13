using ScheepsvaartBL.Enums;
using ScheepsvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class OlieTanker : Tanker
    {
        private OlieLading lading;

        public OlieTanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume, OlieLading lading)
            : base(naam, lengte, breedte, tonnage, cargowaarde, volume)
        {
            this.lading = lading;
        }
    }
}
