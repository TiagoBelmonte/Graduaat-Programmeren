using FitnessBL.Enum;
using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Klant
    {
        private string voornaam;
        private string achternaam;
        private string email;
        private string verblijfplaats;
        private DateTime GeboorteDatum;
        public List<String> intereses;
        public KlantType type;
        public string Voornaam
        {
            get { return voornaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("setVoornaam"); 
                }
                voornaam = value;
            }
        }

        public string Achternaam
        {
            get { return achternaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("setAchternaam"); 
                }
                achternaam = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("setEmail"); 
                }
                email = value;
            }
        }
        public string Verblijfplaats
        {
            get { return verblijfplaats; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("setVerblijfplaats");
                }
                verblijfplaats = value;
            }
        }
        public DateTime GebooorteDatum
        { 
            get { return GeboorteDatum; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new DomeinExceptions("setGeboorteDatum");
                }
                GeboorteDatum = value;
            }
        }

        public int? Id { get; } // Wordt door de database gegenereerd

        public Klant(string voornaam, string achternaam, string email, string verblijfplaats, DateTime gebooorteDatum,KlantType type)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Verblijfplaats = verblijfplaats;
            GebooorteDatum = gebooorteDatum;
            this.type = type;
        }

        public Klant(List<string> intereses, string voornaam, string achternaam, string email, string verblijfplaats, DateTime gebooorteDatum, KlantType type)
        {
            this.intereses = intereses;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Verblijfplaats = verblijfplaats;
            GebooorteDatum = gebooorteDatum;
            this.type = type;
        }

        public void voegInteresseToe(string interesse)
        {
            if (intereses.Contains(interesse))
            {
                throw new DomeinExceptions("Interesse zit al in de lijst");
            }
            else { intereses.Add(interesse); }
            
            
        }

        public void VerwijderInteresse(string interesse)
        {
            if (intereses.Contains(interesse))
            {
                intereses.Remove(interesse);
            }
            else { throw new DomeinExceptions("Interesse zit niet in de lijst"); }           
            
        }

    }
}
