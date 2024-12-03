using TuinCentrumBL.Model;
using TuinCentrumDL_File;

namespace testRepo
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileProcessor processor = new FileProcessor();
            string fileName = @"C:\Users\tbelm\Documenten\programmeren gevorderd\tuin\klanten.txt";
            Console.WriteLine("Hello, World!");
            processor.LeesKlant(fileName);
            List<Klant> klanten = processor.getKlanten();

            foreach (Klant klant in klanten)
            {
                Console.WriteLine(klant);
            }
        }
    }
}
