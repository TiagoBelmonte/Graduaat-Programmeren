using StripsBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model
{
    public class Uitgeverij
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

        private string mail;
        public string Mail
        {
            get { return mail; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("setMaill"); mail = value;
                }
            }
        }

        public Uitgeverij(string naam, string mail)
        {
            Naam = naam;
            Mail = mail;
        }
    }
}
