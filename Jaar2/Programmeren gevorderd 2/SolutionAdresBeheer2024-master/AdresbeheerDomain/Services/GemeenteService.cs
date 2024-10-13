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
    public class GemeenteService
    {
        private IGemeenteRepository repo;

        public GemeenteService(IGemeenteRepository repo)
        {
            this.repo = repo;
        }

        public Gemeente GeefGemeente(int id)
        {
            try
            {
                return repo.GeefGemeente(id);
            }
            catch(Exception ex) { throw new GemeenteServiceException("Geefgemeente", ex); }
        }
    }
}
