using AdresbeheerDomain.Exceptions;
using AdresbeheerDomain.Interfaces;
using AdresbeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDomain.Services
{
    public class StraatService
    {
        private IStraatRepository repo;

        public StraatService(IStraatRepository repo)
        {
            this.repo = repo;
        }

        public List<Straat> GeefStratenGemeente(int gemeenteId)
        {
            try
            {
                return repo.GeefStratenGemeente(gemeenteId);
            }
            catch(Exception ex)
            {
                throw new StraatServiceException("Geefstratengemeente", ex);
            }
        }
    }
}
