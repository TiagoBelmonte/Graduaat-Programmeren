using ScheepsvaartBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class GasTanker : Tanker
    {
        private GasLading lading;

        public GasTanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume, GasLading lading)
            : base(naam, lengte, breedte, tonnage, cargowaarde, volume)
        {
            this.lading = lading;
        }
    }
}
