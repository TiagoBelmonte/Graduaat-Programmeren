using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.Model;

namespace TuinCentrumBL.manager
{
    public class TuincentrumManager
    {
        private IFileProcessor fileProcessor;
        private ITuincentrumRepository tuincentrumRepository;

        public TuincentrumManager(IFileProcessor processor, ITuincentrumRepository tuincentrumRepository)
        {
            this.fileProcessor = processor;
            this.tuincentrumRepository = tuincentrumRepository;
        }

        public List<Product> GeefProducten()
        {
            try
            {
                return tuincentrumRepository.GeefProducten(); ;
            }
            catch (Exception ex) { throw new ManagerException("GeefProducten", ex); }
        }

        public Klant HeeftInfoKlant(string naam)
        {
            Klant klant = tuincentrumRepository.LeesKlantViaNaam(naam);
                return klant;   
        }
        public List<Klant> GeefKlanten()
        {
            List<Klant> klanten = tuincentrumRepository.GeefKlanten();
            return klanten;
        }
        public Klant HeeftInfoKlantID(int id)
        {
            Klant klant = tuincentrumRepository.LeesKlantViaID(id);
            return klant;
        }
        public void UploadKlanten(string fileName)
        {
            List<Klant> klanten = fileProcessor.LeesKlant(fileName);
            
            foreach (Klant klant in klanten)
            {   
                    tuincentrumRepository.SchrijfKlant(klant);   
            }
        }
        public void UploadProducten(string fileName)
        {
            List<Product> producten = fileProcessor.LeesProduct(fileName);

            foreach (Product product in producten)
            {
                if (!tuincentrumRepository.HeeftProduct(product))
                {
                    tuincentrumRepository.SchrijfProduct(product);
                }
            }
        }
        public void uploadOfferte(string fileName, string filename2)
        {
            List<Offerte> offertes = fileProcessor.LeesOfferte(fileName, filename2);

            foreach (Offerte offerte in offertes)
            {
                tuincentrumRepository.schrijfOfferte(offerte);
            }
        }
        public void UpdateOfferte(Offerte offerte, Dictionary<int, int> NieuweProductenInt, Dictionary<int, int> VerwijderdProductenInt)
        {
            tuincentrumRepository.UpdateOfferte(offerte,NieuweProductenInt, VerwijderdProductenInt);
        } 
        public double BerekenPrijs(Dictionary<Product, int> winkelkar, bool leveren, bool Aanleg, double totalePrijs)
        {

                foreach (Product product in winkelkar.Keys)
                {
                    
                    totalePrijs += product.Prijs * winkelkar[product];
                }

                double korting = 0;
                if (totalePrijs > 5000)
                {
                    korting = 0.10;
                    totalePrijs -= totalePrijs * korting;
                }
                else if (totalePrijs > 2000)
                {
                    korting = 0.05;
                    totalePrijs -= totalePrijs * korting;
                }
                

                // Bereken leveringskosten
                if (leveren)
                {
                    if (totalePrijs < 500)
                    {
                        totalePrijs += 100;
                    }
                    else if (totalePrijs < 1000)
                    {
                        totalePrijs += 50;
                    }
                }

                // Bereken aanlegkosten
                if (Aanleg)
                {
                    double aanlegKost = 0;
                    if (totalePrijs > 5000)
                    {
                        aanlegKost = 0.05;
                    }
                    else if (totalePrijs > 2000)
                    {
                        aanlegKost = 0.10;
                    }
                    else
                    {
                        aanlegKost = 0.15;
                    }
                    totalePrijs += totalePrijs * aanlegKost;
                }

                return totalePrijs;
        }
    }

}
