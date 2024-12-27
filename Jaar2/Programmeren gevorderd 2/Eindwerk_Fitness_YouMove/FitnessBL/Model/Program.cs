using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Program
    {
        // Velden
        private string name;
        private string target;
        private DateTime startdate;
        private int max_members;
        private List<Member> members;

        public string? programCode { get; }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("name mag niet leeg zijn.");
                }
                name = value;
            }
        }

        public string Target
        {
            get { return target; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("target mag niet leeg zijn.");
                }
                target = value;
            }
        }

        public DateTime Startdate
        {
            get { return startdate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new DomeinExceptions("startdate mag niet in het verleden liggen.");
                }
                startdate = value;
            }
        }

        public int Max_members
        {
            get { return max_members; }
            set
            {
                if (value <= 0)
                {
                    throw new DomeinExceptions("Max leden moet groter dan 0 zijn.");
                }
                max_members = value;
            }
        }

        public List<Member> Members
        {
            get { return members; }
            set
            {
                if (value == null)
                {
                    throw new DomeinExceptions("De klantenlijst mag niet null zijn.");
                }
                members = value;
            }
        }

        public Program(string code,string name, string target, DateTime startdate, int max_members, List<Member> members)
        {
            programCode = code;
            Name = name;
            Target = target;
            Startdate = startdate;
            Max_members = max_members;
            Members = members ?? new List<Member>(); // Zorgt ervoor dat members nooit null is
        }

        // Methoden
        public void VoegKlantToe(Member klant)
        {
            if (members.Count >= max_members)
            {
                throw new DomeinExceptions("Maximaal aantal leden is bereikt.");
            }

            if (members.Contains(klant))
            {
                throw new DomeinExceptions("De klant is al toegevoegd.");
            }

            members.Add(klant);
        }

        public void VerwijderKlant(Member klant)
        {
            if (!members.Contains(klant))
            {
                throw new DomeinExceptions("De klant is niet gevonden in de lijst.");
            }

            members.Remove(klant);
        }
    }
}
