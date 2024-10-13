using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDomain.Model
{
    public class Straat
    {
        public Straat(int id, string straatnaam, Gemeente gemeente)
        {
            Id = id;
            Straatnaam = straatnaam;
            Gemeente = gemeente;
        }

        public int Id { get; set; }
        public string Straatnaam { get; set; }
        public Gemeente Gemeente { get; set; }
    }
}
