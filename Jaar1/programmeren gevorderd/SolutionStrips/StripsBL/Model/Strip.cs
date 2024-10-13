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

        public Strip(string titel, List<Auteur> auteurs)
        {
            Titel = titel;
            Auteurs = auteurs;
        }

        public IReadOnlyList<Auteur> Auteurs
        {
            get { return auteurs; }
            set
            {
                if ((value == null) || (value.Count<1)) throw new DomeinException("SetAuteurs");
                    foreach (Auteur auteur in value) {  VoegAuteurToe(auteur); }
                 
            } 
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
