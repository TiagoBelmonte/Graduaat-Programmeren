using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Exceptions;

namespace VisStatsBL.Model
{
    public class Haven
    {
        public int? ID { get; set; }
        private string naam;

        public Haven(string naam)
        { 
            Naam = naam;
        }

        public Haven(int? iD, string naam)
        { 
            ID = iD;
            Naam = naam;
        }

        public string Naam
        {
            get { return naam; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Haven_naam niet correct"); naam = value; }
        }

        public override string ToString()
        {
            return Naam;
        }

    }
}
