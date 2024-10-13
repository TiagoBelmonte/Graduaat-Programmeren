using ScheepsvaartBL.Model;
using ScheepvaartBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScheepvaartBL.Model
{
    public class Rederij
    {
        //dictionary<String,Vloot> vloten List<Haven> havens

        public Rederij(Dictionary<String, Vloot> vloten, SortedList<string, Haven> havens)
        {
            Vloten = vloten;
            Havens = havens;

            foreach (Vloot vloot in vloten.Values)
            {
                foreach (Schip schip in vloot.Schepen.Values)
                { 
                    schip.Vloot = vloot;
                }
            }
        }

        public Dictionary<String, Vloot> Vloten { get; }

        public void VoegVlootToe(Vloot vloot)
        { if (vloot == null)
            {
                throw new VlootException("Ongeldigde vloot meegegeven");
            }
            else
            {
                if (!Vloten.ContainsKey(vloot.Naam.ToLower()))
                {
                    Vloten.Add(vloot.Naam.ToLower(), vloot);
                }
                else
                {
                    throw new VlootException("Vloot zit al in de lijst");
                }
            }
           
        }

        public void VerwijderVloot(Vloot vloot)
        {
            if (vloot == null)
            {
                throw new VlootException("Ongeldigde vloot meegegeven");
            }
            else
            {
                if (Vloten.ContainsKey(vloot.Naam.ToLower()))
                {
                    Vloten.Remove(vloot.Naam.ToLower());
                }
                else
                {
                    throw new VlootException("Vloot zit niet in de lijst");
                }
            }
            
        }

        public SortedList<string, Haven> Havens { get; }

        public void VoegHavenToe(Haven haven)
        {
            if (haven == null)
            {
                throw new HavenException("Ongeldigde Haven meegegeven");
            }
            else
            { 
            
                if (!Havens.Values.Contains(haven))
                {
                    Havens.Add(haven.Naam,haven);
                }
                else
                {
                    throw new HavenException("Haven zit al in de lijst");
                }
            }
        }

        public void VerwijderHaven(Haven haven)
        {
            if (haven == null)
            {
                throw new HavenException("Ongeldigde Haven meegegeven");

            }
            else
            {
                if (Havens.Values.Contains(haven))
                {
                    Havens.Remove(haven.Naam);
                }
                else
                {
                    throw new HavenException("Haven zit niet in de lijst");
                }
            }
           
        }

        public void verplaatsSchip(Schip schip, Vloot NieuwVloot)
        {
            if (NieuwVloot == null)
            {
                throw new VlootException("Ongeldige vloot meegegeven");
            }
            else {
                if (schip == null)
                {
                    throw new VlootException("Ongeldige schip meegegeven");
                }
            else
                {
                    if ((schip.Vloot == null || !schip.Vloot.Equals(NieuwVloot)))
                    {
                        if (schip.Vloot != null)
                        {
                            Vloot huidigVloot = schip.Vloot;
                            huidigVloot.VerwijderSchip(schip);
                        }
                        NieuwVloot.VoegSchipToe(schip);
                    }
                    else
                    {
                        throw new VlootException("Het schip zit al in de vloot");
                    }
                }
                
            }
        }

        public List<string> geordendeHavensPrinten()
        { 
            List<string> onGeordend = new List<string>();
            List<string> geordend = new List<string>();

            foreach (Haven haven in Havens.Values)
            {
                onGeordend.Add(haven.Naam.ToLower());
            }
            onGeordend.Sort();
            foreach (string s in onGeordend)
            { 
                geordend.Add(s.ToLower());
            }
            return geordend;
        }

        public Decimal BerekenTotaleCargowaarde()
        {
            Decimal CargoSom = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                List<Vrachtship> vrachtSchepenKinderen = vloot.Schepen.Values.OfType<Vrachtship>().ToList();

                foreach (Vrachtship ship in vrachtSchepenKinderen)
                {
                    CargoSom += ship.Cargowaarde;
                }
            }
            return CargoSom;
        }

        public int berekenTotaalAantalPassagiers()
        {
            int somPassagiers = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                List<Passagiersschip> passagiersschips = vloot.Schepen.Values.OfType<Passagiersschip>().ToList();

                foreach (Passagiersschip ship in passagiersschips)
                {

                    // Assuming Vrachtschip has a property for cargo value
                    somPassagiers += ship.Passagiers;
                }
            }
           return somPassagiers;
        }

        public Dictionary<Vloot, double> berekenTonnagePerVloot()
        {
            Dictionary<Vloot, double> tonnagesPerVloot = new Dictionary<Vloot, double>();
            foreach (Vloot vloot in Vloten.Values)
            {
                double totaalTonnage = 0;
                foreach (Schip ship in vloot.Schepen.Values)
                {
                    totaalTonnage += ship.Tonnage;
                }
                tonnagesPerVloot.Add(vloot, totaalTonnage);

            }

            return tonnagesPerVloot;
        }

        public double BerekenTotaalVolumeTankers()
        {
            double totaalVolume = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                List<Tanker> tankers = vloot.Schepen.Values.OfType<Tanker>().ToList();

                foreach (Tanker ship in tankers)
                {
                    totaalVolume += ship.Volume;
                }
            }
            return totaalVolume;
        }

        public int BerekenAantalSleepboten()
        {
            int aantal = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                List<Sleepboot> sleepboten = vloot.Schepen.Values.OfType<Sleepboot>().ToList();
                aantal += sleepboten.Count();
            }
            return aantal;
        }
    }
}
