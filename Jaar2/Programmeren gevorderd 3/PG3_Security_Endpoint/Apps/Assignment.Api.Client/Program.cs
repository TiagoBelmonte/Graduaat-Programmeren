#if EXAMPLE
using Flurl.Http;
#endif

namespace Assignment.Api.Client
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
#if EXAMPLE
        //var alleKlanten = "https://localhost:7144/api/Klanten?OrderBy=FirstName".GetAsync().Result;
        var eenEnkeleKlant = "https://localhost:7144/api/Klanten/1".GetAsync().Result;
        Klant klant = "https://localhost:7144/api/Klanten/1".GetJsonAsync<Klant>().Result;

        var s = eenEnkeleKlant.GetStringAsync().Result;
#endif
        }
    }
}
