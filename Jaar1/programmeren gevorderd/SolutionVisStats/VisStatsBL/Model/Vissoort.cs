using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Exceptions;

namespace VisStatsBL.Model
{
    public class Vissoort
    {
        private string naam;

        public Vissoort(string naam)
        {
            Naam = naam;
        }

        public Vissoort(string naam, int id)
        {
            Naam = naam;
            Id = id;
        }

        public string Naam {
            get { return naam;}
            set { if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException
                        ($"Vissoort.Naam - {value}");
                        naam = value;   
            } }
        public int Id { get; set; }

        public override string ToString()
        {
            return naam; 
        }
    }
}
