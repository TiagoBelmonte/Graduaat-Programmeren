using StripsBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model
{
    public class Reeks
    {
        public int? id;
        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("setNaam"); naam = value;
                }
            }
        }

        private List<Strip> strips;
        public IReadOnlyList<Strip> Strips
        {
            get { return strips; }
            set
            {
                if ((value == null) || (value.Count < 1)) throw new DomeinException("Strips");
                foreach (Strip strip in value) { VoegStripToe(strip); }

            }
        }

        public Reeks(string naam)
        {
            Naam = naam;
        }


        public void VoegStripToe(Strip strip)
        {
            if (strip == null || strips.Contains(strip))
            {
                throw new DomeinException("VoegStripToe");
            }
            strips.Add(strip);
        }
    }
}
