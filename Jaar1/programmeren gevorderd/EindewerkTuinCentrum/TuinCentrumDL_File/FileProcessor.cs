using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.Model;

namespace TuinCentrumDL_File
{
    public class FileProcessor : IFileProcessor
    {
        public List<Klant> klanten = new List<Klant>();
        public List<Product> producten = new List<Product>();
        public List<Offerte> offertes = new List<Offerte>();


        List<Klant> IFileProcessor.LeesKlant(string fileName)
        {
            try
            {
                String[] data = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");

                        int id;
                        int.TryParse(data[0], out id);
                        string naam = data[1];
                        string adres = data[2];

                        Klant klant = new Klant(id, naam, adres);
                        klanten.Add(klant);

                    }
                }
                return klanten;
            }
            catch (Exception ex) { throw new Exception($"FileProcessor.leesKlanten - {fileName}", ex); }
        }
        List<Product> IFileProcessor.LeesProduct(string fileName)
        {
            try
            {
                String[] data = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");

                        int id;
                        int.TryParse(data[0], out id);
                        string nednaam = data[1];
                        string wetNaam = data[2];
                        double prijs;
                        double.TryParse(data[3], out prijs);
                        string beschrijving = data[4];

                        Product product = new Product(id, nednaam, wetNaam,prijs,beschrijving);
                        producten.Add(product);

                    }
                }
                return producten;
            }
            catch (Exception ex) { throw new Exception($"FileProcessor.leesProducten - {fileName}", ex); }
        }
        List<Offerte> IFileProcessor.LeesOfferte(string fileName, string filename2)
        {
            try
            {
                String[] data = null;
                String[] data2 = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");


                        int id;
                        int.TryParse(data[0], out id);
                        string datumString = data[1];
                        DateTime datum = DateTime.Parse(datumString);
                        int klantnummer;
                        int.TryParse(data[2], out klantnummer);
                        string afhaaltekst = data[3];
                        bool afhaal = true;
                        if (afhaaltekst.ToLower() == "false")
                        {
                            afhaal = false;
                        }
                        string aanlegtekst = data[4];
                        bool aanleg = true;
                        if (aanlegtekst.ToLower() == "false")
                        {
                            aanleg = false;
                        }
                        int aantal;
                        int.TryParse(data[5], out aantal);
                        double prijs = 0.0;

                        Offerte offerte = new Offerte(id,datum,klantnummer,afhaal,aanleg,aantal, prijs);


                        using (StreamReader sr2 = new StreamReader(filename2))
                        {
                            string line2;


                            while ((line2 = sr2.ReadLine()) != null)
                            {
                                data2 = line2.Split("|");
                                int offerteid;
                                int.TryParse(data2[0], out offerteid);

                                if (offerteid == id)
                                {
                                    int product;
                                    int.TryParse(data2[1], out product);
                                    int aantalP;
                                    int.TryParse(data2[2],out aantalP);

                                    offerte.voegProductToe(product,aantalP);
                                }

                            }
                        }
                        offertes.Add(offerte);
                    }
                    return offertes;
                }
            }
            catch (Exception ex) { throw new Exception($"FileProcessor.leesOfferte - {fileName}", ex); }
        }

    }
}