using AdresbeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDomain.Interfaces
{
    public interface IStraatRepository
    {
        List<Straat> GeefStratenGemeente(int gemeenteId);
    }
}
