using StripsBL.Exceptions;
using System;
using System.Collections.Generic;

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
                    throw new DomeinException("setTitel");
                }
                titel = value;
            }
        }

        private List<Auteur> auteurs;

        public IReadOnlyList<Auteur> Auteurs
        {
            get { return auteurs; }
        }

        private Uitgeverij uitgeverij;

        public Uitgeverij Uitgeverij
        {
            get { return uitgeverij; }
            set
            {
                if (value == null)
                {
                    throw new DomeinException("setUitgeverij");
                }
                uitgeverij = value;
            }
        }

        private Reeks reeks;

        public Reeks Reeks
        {
            get { return reeks; }
            set
            {
                if (value == null)
                {
                    throw new DomeinException("setReeks");
                }
                reeks = value;
            }
        }

        private int reeksNR;

        public int ReeksNR
        {
            get { return reeksNR; }
            set
            {
                reeksNR = value;
            }
        }

        // Constructor zonder 'this' en zonder controle op auteurs
        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij)
        {
            Titel = titel;
            this.auteurs = new List<Auteur>();
            Uitgeverij = uitgeverij;

            VoegAuteursToe(auteurs); // Auteurs toevoegen via de nieuwe methode
        }

        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij, Reeks reeks)
        {
            Titel = titel;
            this.auteurs = new List<Auteur>();
            Uitgeverij = uitgeverij;
            Reeks = reeks;

            VoegAuteursToe(auteurs); // Auteurs toevoegen via de nieuwe methode
        }

        public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij, Reeks reeks, int reeksNR)
        {
            Titel = titel;
            this.auteurs = new List<Auteur>();
            Uitgeverij = uitgeverij;
            Reeks = reeks;
            ReeksNR = reeksNR;

            VoegAuteursToe(auteurs); // Auteurs toevoegen via de nieuwe methode
        }

        // Methode om meerdere auteurs toe te voegen
        public void VoegAuteursToe(List<Auteur> auteurs)
        {
            if (auteurs == null || auteurs.Count < 1)
            {
                throw new DomeinException("SetAuteurs");
            }

            foreach (var auteur in auteurs)
            {
                if (auteur == null || this.auteurs.Contains(auteur))
                {
                    throw new DomeinException("VoegAuteursToe");
                }
                this.auteurs.Add(auteur);
            }
        }

        public void VerwijderAuteur(Auteur auteur)
        {
            if (auteur == null || !auteurs.Contains(auteur) || auteurs.Count <= 1)
            {
                throw new DomeinException("VerwijderAuteur");
            }
            auteurs.Remove(auteur);
        }
    }
}
