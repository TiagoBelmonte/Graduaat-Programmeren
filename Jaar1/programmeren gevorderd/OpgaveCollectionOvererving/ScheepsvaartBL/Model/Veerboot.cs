using ScheepsvaartBL.Exceptions;
using ScheepvaartBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepsvaartBL.Model
{
    public class Veerboot : Passagiersschip
    {
        private Dictionary<Haven, Haven> traject;


        public Dictionary<Haven, Haven> Traject
        {
            get { return traject; }
            set { if (value == null || value.Count != 1) throw new DomeinException("Veerboot_Traject niet correct"); traject = value; }
        }
        public Veerboot(string naam, double lengte, double breedte, double tonnage, int passagiers, Dictionary<Haven, Haven> traject)
            : base(naam, lengte, breedte, tonnage, passagiers)
        {
            Traject = traject;
        }
    }
}
