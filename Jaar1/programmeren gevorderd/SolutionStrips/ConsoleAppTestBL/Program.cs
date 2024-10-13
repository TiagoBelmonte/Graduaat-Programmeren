using StripsBL.Exceptions;
using StripsBL.Model;

namespace ConsoleAppTestBL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Auteur a1 = new Auteur("Jos","jos@gmail");
            Auteur a2 = new Auteur("Jos", "jos@gmail");

            List<Auteur> list = new List<Auteur>();
            list.Add(a1);
            try
            {
                Strip s = new Strip("titel", list);
                s.VoegAuteurToe(a2);
            }
            catch (DomeinException) { Console.WriteLine("ok"); }
            Console.WriteLine();
           
        }
    }
}
