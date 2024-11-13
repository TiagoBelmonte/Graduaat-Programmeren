using StripsBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model
{
    public class Strip
    {
        public int? id;
        private string titel;
        public string Titel
        {
            get { return titel; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("setTitel"); titel = value;
                } 
            }
        }
        private List<Auteur> auteurs;
        public IReadOnlyList<Auteur> Auteurs
        {
            get { return auteurs; }
            set
            {
                if ((value == null) || (value.Count < 1)) throw new DomeinException("SetAuteurs");
                foreach (Auteur auteur in value) { VoegAuteurToe(auteur); }

            }
        }

        private Uitgeverij uitgeverij;
        public Uitgeverij Uitgeverij
        {
            get { return uitgeverij; }
            set
            {
                if ((value == null) || string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    throw new DomeinException("setUitgeverij"); 
                    uitgeverij = value;
                }
            }
        }

        private Reeks reeks;
        public Reeks Reeks
        {
            get { return reeks; ; }

            set
            {
                if (Convert.ToString(value) != "<geen serie>")
                {
                    reeks = value;
                }
            }
        }

        private int reeksNR;
        public int ReeksNR
        {
            get { return reeksNR; ; }

            set
            {
                if (value != null)
                {
                    reeksNR = value;
                }

            }
        }

        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij)
        {
            Titel = titel;
            Auteurs = auteurs;
            Uitgeverij = uitgeverij;
        }

        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij, Reeks reeks)
        {
            Titel = titel;
            Auteurs = auteurs;
            Uitgeverij = uitgeverij;
            Reeks = reeks;
        }

        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij, Reeks reeks, int reeksNR)
        {
            Titel = titel;
            Auteurs = auteurs;
            Uitgeverij = uitgeverij;
            Reeks = reeks;
            ReeksNR = reeksNR;
        }


        public void VoegAuteurToe(Auteur auteur)
        {
            if (auteur == null || auteurs.Contains(auteur))
            {
                throw new DomeinException("VoegAuteurToe");
            }
            auteurs.Add(auteur);
        }
        public void VerwijderAuteur(Auteur auteur)
        {
            if (auteur == null || !auteurs.Contains(auteur) || auteurs.Count<=1)
            {
                throw new DomeinException("VerwijderAuteur");
            }
            auteurs.Remove(auteur);
        }
    }
}
