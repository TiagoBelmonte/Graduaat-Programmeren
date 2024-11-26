using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Toestel
    {
        public int? Id { get; } // Wordt door de database gegenereerd
        private string beschrijving;

        public Toestel(string beschrijving)
        {
            Beschrijving = beschrijving;
        }

        public string Beschrijving
        {
            get { return beschrijving; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("setBeschrijving");
                }
                beschrijving = value;
            }
        }

    }
}
