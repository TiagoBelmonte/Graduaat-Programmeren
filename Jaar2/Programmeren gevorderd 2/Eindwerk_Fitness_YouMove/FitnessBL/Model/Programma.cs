using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;

namespace FitnessBL.Model
{
    public class Programma
    {
        // Velden
        private string naam;
        private string doelpubliek;
        private DateTime startdatum;
        private int maxLeden;
        private List<Klant> klanten;

        // Eigenschappen
        public int? Id { get;} // Wordt door de database gegenereerd

        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("Naam mag niet leeg zijn.");
                }
                naam = value;
            }
        }

        public string Doelpubliek
        {
            get { return doelpubliek; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("Doelpubliek mag niet leeg zijn.");
                }
                doelpubliek = value;
            }
        }

        public DateTime Startdatum
        {
            get { return startdatum; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new DomeinExceptions("Startdatum mag niet in het verleden liggen.");
                }
                startdatum = value;
            }
        }

        public int MaxLeden
        {
            get { return maxLeden; }
            set
            {
                if (value <= 0)
                {
                    throw new DomeinExceptions("Max leden moet groter dan 0 zijn.");
                }
                maxLeden = value;
            }
        }

        public List<Klant> Klanten
        {
            get { return klanten; }
            set
            {
                if (value == null)
                {
                    throw new DomeinExceptions("De klantenlijst mag niet null zijn.");
                }
                klanten = value;
            }
        }

        // Constructors
        public Programma(string naam, string doelpubliek, DateTime startdatum, int maxLeden)
        {
            Naam = naam;
            Doelpubliek = doelpubliek;
            Startdatum = startdatum;
            MaxLeden = maxLeden;
            klanten = new List<Klant>();
        }

        public Programma(string naam, string doelpubliek, DateTime startdatum, int maxLeden, List<Klant> klanten)
        {
            Naam = naam;
            Doelpubliek = doelpubliek;
            Startdatum = startdatum;
            MaxLeden = maxLeden;
            Klanten = klanten;
        }

        // Methoden
        public void VoegKlantToe(Klant klant)
        {
            if (klanten.Count >= maxLeden)
            {
                throw new DomeinExceptions("Maximaal aantal leden is bereikt.");
            }

            if (klanten.Contains(klant))
            {
                throw new DomeinExceptions("De klant is al toegevoegd.");
            }

            klanten.Add(klant);
        }

        public void VerwijderKlant(Klant klant)
        {
            if (!klanten.Contains(klant))
            {
                throw new DomeinExceptions("De klant is niet gevonden in de lijst.");
            }

            klanten.Remove(klant);
        }
    }
}
