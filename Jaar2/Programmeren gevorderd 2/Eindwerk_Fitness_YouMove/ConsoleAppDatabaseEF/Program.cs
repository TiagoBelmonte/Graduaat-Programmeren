using FitnesDataEF;

namespace ConsoleAppDatabaseEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Trust Server Certificate=True";

            // Initialiseer de context met de gekozen connectionString
            FitnessContext ctx = new FitnessContext(connectionString);

            // Databasebeheer
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Console.WriteLine("Database is opnieuw aangemaakt.");
        }
    }
}
