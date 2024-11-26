using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Reservatie
    {
        private Klant klant;
        private DateTime startdatum;

        public Reservatie(Klant klant, DateTime startdatum)
        {
            Klant = klant;
            Startdatum = startdatum;
        }

        public Klant Klant { 
            get { return klant; }
            set {
                if (value == null)
                {
                    throw new DomeinExceptions("Klant mag niet null zijn.");
                }
                klant = value;
            }
        }
        public DateTime Startdatum
        {
            get { return startdatum; }
            set 
            {
                if (value > DateTime.Now)
                {
                    throw new DomeinExceptions("setStartDatum");
                }
                startdatum = value;
            }
        }


                
    }
}
