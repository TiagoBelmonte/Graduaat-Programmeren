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
    public class Cruiseschip : Passagiersschip
    {
        private List<Haven> traject;

        public List<Haven> Traject
        {
            get { return traject; }
            set { if (value.Count < 2 ) throw new DomeinException("Cruiseschip_Traject niet correct"); traject = value; }
        }
        public Cruiseschip(string naam, double lengte, double breedte, double tonnage, int passagiers, List<Haven> traject)
            : base(naam, lengte, breedte, tonnage, passagiers)
        {
            Traject = traject;
        }

        public void voegHavenToe(Haven haven, Haven stopErvoor)
        {
            if (haven == null)
            {
                throw new HavenException("Ongeldige haven meegegeven");
            }
            else
            { 
                if(!traject.Contains(stopErvoor))
                {
                    throw new DomeinException("Haven zit niet in traject");
                }
                else
                {         
                  int index = traject.IndexOf(stopErvoor);
                    traject.Insert(index + 1, haven);
                }
            }
        }
    }
}
