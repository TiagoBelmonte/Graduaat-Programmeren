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
    public class Sleepboot : Schip
    {
        public Sleepboot(string naam, double lengte, double breedte, double tonnage) : base(naam, lengte, breedte, tonnage)
        {
        }
    }
}
