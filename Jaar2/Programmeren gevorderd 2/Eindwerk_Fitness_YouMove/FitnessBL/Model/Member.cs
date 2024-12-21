using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FitnessBL.Enum;
using FitnessBL.Exceptions;

namespace FitnessBL.Model
{
    public class Member
    {
        private string voornaam;
        private string achternaam;
        private string email;
        private string verblijfplaats;
        private DateTime geboorteDatum;
        private readonly int? id;

        public List<string> Interesses { get; private set; } = new List<string>();
        public KlantType Type { get; set; }

        public string Voornaam
        {
            get { return voornaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("Voornaam mag niet leeg zijn");
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
                    throw new DomeinExceptions("Achternaam mag niet leeg zijn");
                }
                achternaam = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                // E-mail validatie met Regex
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new DomeinExceptions("Ongeldig e-mailadres!");
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
                    throw new DomeinExceptions("U gemeente mag niet leeg zijn");
                }
                verblijfplaats = value;
            }
        }

        public DateTime GeboorteDatum
        {
            get { return geboorteDatum; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new DomeinExceptions("U kan niet geboren zijn in de toekomst");
                }
                geboorteDatum = value;
            }
        }

        public int? Id
        {
            get { return id; }
        }

        // Constructor zonder Id, zodat de database de Id instelt
        public Member(string voornaam, string achternaam, string email, string verblijfplaats, DateTime geboorteDatum, KlantType type)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email; // E-mail wordt gevalideerd bij het instellen
            Verblijfplaats = verblijfplaats;
            GeboorteDatum = geboorteDatum;
            Type = type;
        }
        public Member(string voornaam, string achternaam, string email, string verblijfplaats, DateTime geboorteDatum)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email; // E-mail wordt gevalideerd bij het instellen
            Verblijfplaats = verblijfplaats;
            GeboorteDatum = geboorteDatum;
        }

        // Constructor met interesses, zonder Id
        public Member(List<string> interesses, string voornaam, string achternaam, string email, string verblijfplaats, DateTime geboorteDatum, KlantType type)
        {
            Interesses = interesses ?? new List<string>();
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email; // E-mail wordt gevalideerd bij het instellen
            Verblijfplaats = verblijfplaats;
            GeboorteDatum = geboorteDatum;
            Type = type;
        }

        public void VoegInteresseToe(string interesse)
        {
            if (Interesses.Contains(interesse))
            {
                throw new DomeinExceptions("Deze interesse zit al in de lijst");
            }
            Interesses.Add(interesse);
        }

        public void VerwijderInteresse(string interesse)
        {
            if (!Interesses.Contains(interesse))
            {
                throw new DomeinExceptions("Deze interesse zit niet in de lijst");
            }
            Interesses.Remove(interesse);
        }

        public override string ToString()
        {
            // Bouw de string op met de relevante eigenschappen
            return $"Member: {voornaam} {achternaam}\n" +
                   $"Email: {email}\n" +
                   $"Verblijfplaats: {verblijfplaats}\n" +
                   $"Geboortedatum: {geboorteDatum.ToString("yyyy-MM-dd")}\n" +
                   $"ID: {(id.HasValue ? id.Value.ToString() : "Onbekend")}\n" +
                   $"Interesses: {(Interesses.Any() ? string.Join(", ", Interesses) : "Geen interesses")}";
        }
    }
}
