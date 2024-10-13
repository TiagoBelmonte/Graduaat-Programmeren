using ScheepvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Model
{
    public class Haven
    {
        public Haven(string naam)
        {
            Naam = naam;
        }
        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))throw new HavenException("Naam"); naam = value;
            }
        }
    }
}
