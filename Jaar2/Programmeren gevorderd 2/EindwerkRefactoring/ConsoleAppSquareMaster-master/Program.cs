using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppSquareMaster
{
    internal class Program
    {
        // De Main-methode is nu asynchroon, zodat we asynchrone database-operaties kunnen uitvoeren
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Stap 1: Wereld genereren
            World world = new World();
            // Genereer een wereld met 100x100 vakjes en een land/water-verhouding van 60%
            var initialWorld = world.BuildWorld2(100, 100, 0.60);

            // Print de gegenereerde wereld op de console
            PrintWorld(initialWorld);

            // Initialiseer een WorldConquer-object met de gegenereerde wereld
            WorldConquer wq = new WorldConquer(initialWorld);

            // Maak een lijst met algoritmen en koppel ze aan unieke nummers
            var conquerStrategies = new Dictionary<int, Func<int, int, int[,]>>()
            {
                { 1, wq.Conquer1 },
                { 2, wq.Conquer2 },
                { 3, wq.Conquer3 }
            };

            // Stel in hoeveel rijken er zijn en hoeveel stappen elk algoritme mag uitvoeren
            int nEmpires = 5; // Aantal rijken
            int turns = 25000; // Totaal aantal stappen verdeeld over de rijken

            // Koppel elk rijk aan een willekeurig veroveringsalgoritme
            Random random = new Random();
            Dictionary<int, int> empireStrategies = new Dictionary<int, int>();
            for (int i = 1; i <= nEmpires; i++)
            {
                // Wijs een willekeurig algoritme toe (Conquer1, Conquer2 of Conquer3)
                empireStrategies[i] = random.Next(1, 4);
            }

            // Lijst om de resultaten van de simulaties op te slaan
            List<BsonDocument> results = new List<BsonDocument>();

            // Voer meerdere simulaties uit
            for (int simulation = 1; simulation <= 3; simulation++) // Bijvoorbeeld 3 simulaties
            {
                Console.WriteLine($"Start simulation {simulation}...");

                // Voor elke empire, voer het toegewezen algoritme uit
                foreach (var empire in empireStrategies)
                {
                    Console.WriteLine($"Empire {empire.Key} uses Conquer{empire.Value}");

                    // Roep het juiste algoritme aan met de huidige empire en verdeelde turns
                    var conqueredWorld = conquerStrategies[empire.Value](empire.Key, turns / nEmpires);

                    // Bereken de grootte en bezettingspercentage van dit rijk
                    int size = CalculateEmpireSize(conqueredWorld, empire.Key);
                    double percent = (double)size / (conqueredWorld.GetLength(0) * conqueredWorld.GetLength(1)) * 100;

                    // Maak een document om de resultaten van dit rijk op te slaan
                    var result = new BsonDocument
                    {
                        { "Simulation", simulation }, // Simulatienummer
                        { "Algorithm", $"Conquer{empire.Value}" }, // Naam van het gebruikte algoritme
                        { "Empire", empire.Key }, // Rijk ID
                        { "Size", size }, // Grootte van het rijk (aantal vakjes)
                        { "Percent", percent } // Percentage van de wereld bezet door dit rijk
                    };

                    // Voeg dit resultaat toe aan de lijst
                    results.Add(result);
                }
            }

            // Sla alle resultaten op in MongoDB
            await SaveResultsToMongoDB(results);

            Console.WriteLine("Simulation complete! Results saved to MongoDB.");
        }

        // Methode om de wereld in de console af te drukken
        static void PrintWorld(bool[,] world)
        {
            // Loop door alle rijen en kolommen van de wereld
            for (int i = 0; i < world.GetLength(1); i++) // Y-coördinaat
            {
                for (int j = 0; j < world.GetLength(0); j++) // X-coördinaat
                {
                    // Bepaal het teken om af te drukken: '*' voor land, ' ' voor water
                    char ch = world[j, i] ? '*' : ' ';
                    Console.Write(ch);
                }
                Console.WriteLine(); // Nieuwe regel na elke rij
            }
        }

        // Methode om de grootte van een rijk te berekenen
        static int CalculateEmpireSize(int[,] world, int empire)
        {
            int size = 0;

            // Loop door alle vakjes in de wereld
            for (int i = 0; i < world.GetLength(1); i++) // Y-coördinaat
            {
                for (int j = 0; j < world.GetLength(0); j++) // X-coördinaat
                {
                    // Tel vakjes die tot het huidige rijk behoren
                    if (world[j, i] == empire)
                    {
                        size++;
                    }
                }
            }

            return size; // Retourneer de totale grootte van het rijk
        }

        // Methode om de resultaten in MongoDB op te slaan
        static async Task SaveResultsToMongoDB(List<BsonDocument> results)
        {
            // Maak verbinding met de MongoDB-database
            var client = new MongoClient("mongodb://localhost:27017"); // Gebruik lokale MongoDB
            var database = client.GetDatabase("WorldConquerDB"); // Database naam
            var collection = database.GetCollection<BsonDocument>("SimulationResults"); // Collectienaam

            // Voeg de resultaten toe aan de collectie
            await collection.InsertManyAsync(results);

            Console.WriteLine("Results saved to MongoDB.");
        }
    }
}
