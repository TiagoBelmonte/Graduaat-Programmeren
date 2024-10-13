using ScheepsvaartBL.Model;
using ScheepvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheepvaartBL.Model
{
    public class Vloot
    {

        private Rederij rederij;
        public Rederij _Rederij
        {
            get { return rederij; }
            set { if (value == null) throw new VlootException("De vloot bestaat niet"); rederij = value; }
        }

        public Vloot(string naam, Dictionary<String, Schip> schepen)
        {
            Naam = naam;
            Schepen = schepen;
        }
        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new HavenException("Naam"); naam = value;
            }
        }
        public Dictionary<String, Schip> Schepen { get; }

        public void VoegSchipToe(Schip schip)
        {
            if (!Schepen.ContainsKey(schip.Naam))
            {
                Schepen.Add(schip.Naam, schip);
            }
            else
            {
                throw new VlootException("Schip zit al in de lijst");
            }
        }

        public void VerwijderSchip(Schip schip)
        {
            if (Schepen.ContainsKey(schip.Naam))
            {
                Schepen.Remove(schip.Naam);
            }
            else
            {
                throw new VlootException("Schip zit niet in de lijst");
            }
        }
    }
}
