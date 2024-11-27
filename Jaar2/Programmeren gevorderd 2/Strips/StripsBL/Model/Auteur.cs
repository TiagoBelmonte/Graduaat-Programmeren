using StripsBL.Exceptions;
using System;

namespace StripsBL.Model
{
    public class Auteur
    {
        private string naam;
        private string email;

        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("setNaam");
                }
                naam = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinException("setEmail");
                }
                email = value;
            }
        }

        public int? id;

        public Auteur(string naam, string email)
        {
            Naam = naam;
            Email = email;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Auteur)
            {
                Auteur compAuteur = (Auteur)obj;
                if (id.HasValue && compAuteur.id == id.Value)
                {
                    if (id == compAuteur.id) return true;
                    else return false;
                }
                else
                {
                    return naam == compAuteur.Naam && email == compAuteur.Email;
                }
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(naam, email, id);
        }
    }
}
