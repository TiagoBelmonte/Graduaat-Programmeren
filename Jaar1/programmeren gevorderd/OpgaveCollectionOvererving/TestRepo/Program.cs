//using ScheepsvaartBL.Enums;
//using ScheepsvaartBL.Model;
//using ScheepvaartBL.Model;
//using System.Security.Cryptography.X509Certificates;

//namespace TestRepo
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            // First set of havenList
//            Haven haven1 = new Haven("Gent");
//            Haven haven2 = new Haven("ruiselede");
//            Haven haven3 = new Haven("tielt");


//            // Second set of havenList (with overlapping ports)
//            Haven haven4 = new Haven("Brugge");
//            Haven haven5 = new Haven("Antwerpen");

//            List<Haven> havenList1 = new List<Haven> { haven1, haven3, haven2 };
//            List<Haven> havenList2 = new List<Haven> { haven1, haven2, haven4, haven5 };
//            List<Haven> havenList3 = new List<Haven> { haven6, haven7 };

//            // Third set of havenList (with different ports)
//            Haven haven6 = new Haven("Oostende");
//            Haven haven7 = new Haven("Zeebrugge");


//            Dictionary<Haven, Haven> traject1 = new Dictionary<Haven, Haven> { { haven1, haven2 } };
//            Dictionary<Haven, Haven> traject2 = new Dictionary<Haven, Haven> { { haven3, haven4 } };
//            Dictionary<Haven, Haven> traject3 = new Dictionary<Haven, Haven> { { haven5, haven6 } };



//            Containerschip containerschip1 = new Containerschip("ss containership1", 123, 123, 100, 10, 23);
//            Containerschip containerschip2 = new Containerschip("ss containership2", 200, 150, 100, 10, 30);
//            Containerschip containerschip3 = new Containerschip("ss containership3", 180, 160, 100, 10, 25);

//            RoRoschip roroschip1 = new RoRoschip("ss roroschip1", 10, 50, 200, 200, 50, 50);
//            RoRoschip roroschip2 = new RoRoschip("ss roroschip2", 12, 60, 200, 200, 60, 55);
//            RoRoschip roroschip3 = new RoRoschip("ss roroschip3", 8, 45, 200, 200, 40, 45);

//            GasTanker gastanker1 = new GasTanker("ss gastanker1", 10, 50, 300, 30, 1000, GasLading.LPG);
//            GasTanker gastanker2 = new GasTanker("ss gastanker2", 12, 300, 35, 30, 1200, GasLading.LNG);
//            GasTanker gastanker3 = new GasTanker("ss gastanker3", 8, 45, 300, 30, 800, GasLading.Amoniak);

//            OlieTanker olietanker2 = new OlieTanker("ss olietanker2", 10, 50, 300, 30, 25, OlieLading.Olie);
//            OlieTanker olietanker3 = new OlieTanker("ss olietanker3", 12, 300, 35, 30, 25, OlieLading.Benzeen);
//            OlieTanker olietanker1 = new OlieTanker("ss olietanker1", 8, 45, 300, 30, 25, OlieLading.Diesel);

//            Cruiseschip cruiseschip1 = new Cruiseschip("ss cruiseschip1", 10, 53, 400, 300, havenList1);
//            Cruiseschip cruiseschip2 = new Cruiseschip("ss cruiseschip2", 12, 60, 400, 300, havenList2);
//            Cruiseschip cruiseschip3 = new Cruiseschip("ss cruiseschip3", 8, 45, 400,300, havenList3);

//            Sleepboot sleepboot1 = new Sleepboot("ss sleepboot1", 55, 66, 500);
//            Sleepboot sleepboot2 = new Sleepboot("ss sleepboot2", 60, 70, 500);
//            Sleepboot sleepboot3 = new Sleepboot("ss sleepboot3", 50, 60, 500);

//            Veerboot veerboot1 = new Veerboot("ss veerboot1", 50.5, 20.3, 600, 200, traject1);
//            Veerboot veerboot2 = new Veerboot("ss veerboot2", 45.8, 18.6, 600, 200, traject2);
//            Veerboot veerboot3 = new Veerboot("ss veerboot3", 48.2, 22.1, 600, 200, traject3);

//            Dictionary<string, Schip> boten1 = new Dictionary<string, Schip>
//            {
//                { containerschip1.Naam, containerschip1 },
//                { roroschip1.Naam, roroschip1 },
//                { containerschip3.Naam, containerschip3 },
//                { cruiseschip1.Naam, cruiseschip1 },
//                { veerboot1.Naam, veerboot1 },
//                { olietanker1.Naam, olietanker1 },
//                { cruiseschip2.Naam, cruiseschip2 }
//            };
            
//            Dictionary<string, Schip> boten2 = new Dictionary<string, Schip>
//            {
//                { containerschip2.Naam, containerschip2 },
//                { olietanker2.Naam, olietanker2 },
//                { roroschip2.Naam, roroschip2 },
//                { gastanker1.Naam, gastanker1 },
//                { gastanker2.Naam, gastanker2 },
//                { veerboot2.Naam, veerboot2 },
//                { sleepboot1.Naam, sleepboot1 },
//                { sleepboot3.Naam, sleepboot3 }, 
//            };

//            Dictionary<string, Schip> boten3 = new Dictionary<string, Schip>
//            {
//                { roroschip3.Naam, roroschip3 },
//                { gastanker3.Naam, gastanker3 },
//                { cruiseschip3.Naam, cruiseschip3 },
//                { veerboot3.Naam, veerboot3 },
//                { olietanker3.Naam, olietanker3 },
//                { sleepboot2.Naam, sleepboot2 }
//            };

//            Vloot vloot1 = new Vloot("ss boten", boten1);
//            Vloot vloot2 = new Vloot("ss auto's", boten2);
//            Vloot vloot3 = new Vloot("ss vliegers", boten3);

//            Dictionary<string, Vloot> vlotengroep = new Dictionary<string, Vloot>
//            {
//                { vloot1.Naam, vloot1},
//                { vloot2.Naam, vloot2},
//                { vloot3.Naam, vloot3},
//            };

//            Rederij rederij = new Rederij(vlotengroep, havenList2);
//            ScheepsvaartManager sm = new ScheepsvaartManager(rederij);

//            int MenuAfprinten()
//            {
//                Console.WriteLine("Menu:");
//                Console.WriteLine("1. Overzicht havens");
//                Console.WriteLine("2. Totale cargowaarde");
//                Console.WriteLine("3. Totaal aantal passagiers");
//                Console.WriteLine("4. Tonnage per vloot");
//                Console.WriteLine("5. totaal grootte volume tankers");
//                Console.WriteLine("6. Haven toevoegen aan rederij");
//                Console.WriteLine("7. Haven verwijderen van rederij");
//                Console.WriteLine("8. Boot verplaatsen van vloot");
//                Console.WriteLine("9. Vloot toevoegen aan rederij");
//                Console.WriteLine("10. Vloot verwijderen van rederij");
//                Console.WriteLine("11. Einde");
//                Console.WriteLine("Wat wil je zien?");
//                int index = int.Parse(Console.ReadLine());
//                return index;
//            }

//            bool stop = false;
//            while (!stop)
//            { 
//                int keuze = MenuAfprinten();
//                switch (keuze)
//                {
//                    case 1: rederij.geordendeHavensPrinten(); break;
//                    case 2: sm.printTotaleCargoWaarde(); break;
//                    case 3: sm.printTotaalAantalPassagiers(); break;
//                    case 4: sm.printTonnagePerVloot(); break;
//                    case 5: sm.printTotaalVolumeTankers(); break;
//                    case 6: Console.Write("Geef de naam van de haven die je wil toevoegen: "); rederij.VoegHavenToe(new Haven(Console.ReadLine())); break;
//                    case 7: Console.Write("Geef de naam van de haven die je wil toevoegen: "); rederij.VerwijderHaven(rederij.Havens.Where(x => x.Naam == Console.ReadLine())); break;
//                    case 8:
//                        Console.Write("Geef de naam van de boot die je wilt verplaatsen van vloot: ");
//                        Console.Write("Geef de naam van de vloot: ");
//                        string naamVloot = Console.ReadLine();
//                        string naamSchip = Console.ReadLine();

//                        bool gelukt = false;
//                        Schip schip = null;
//                        while (!gelukt)
//                        {
//                            foreach (Vloot vloot55 in vlotengroep.Values)
//                            {
                             
//                                gelukt = vloot55.Schepen.TryGetValue(naamSchip, out schip);
//                            }
//                        }

//                        Vloot vloot = vlotengroep[naamVloot];

//                        rederij.verplaatsSchip(schip, vloot);
//                        break;
//                    case 9: sm.printTotaalVolumeTankers(); break;
//                    case 10: sm.printTotaalVolumeTankers(); break;
//                    case 11: stop = true; Console.WriteLine("Bedankt en tot ziens!"); break;
//                    default:
//                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
//                        break;
//                }
//            }
//        }
//    }
//}
