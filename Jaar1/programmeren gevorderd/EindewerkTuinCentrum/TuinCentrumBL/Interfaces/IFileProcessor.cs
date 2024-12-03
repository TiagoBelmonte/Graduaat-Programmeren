using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Model;

namespace TuinCentrumBL.Interfaces
{
    public interface IFileProcessor
    {
        List<Klant> LeesKlant(string fileName);
        List<Offerte> LeesOfferte(string fileName, string filename2);
        List<Product> LeesProduct(string fileName);
    }
}
