using AdresbeheerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDomain.Model
{
    public class Gemeente
    {
        private int nIScode;

        public Gemeente(int nIScode, string gemeentenaam)
        {
            NIScode = nIScode;
            Gemeentenaam = gemeentenaam;
        }

        public int NIScode { 
            get { return nIScode; }
            set { if ((value < 10000) || (value > 99999))
                {
                    GemeenteException ex = new GemeenteException("NIScode niet correct");
                    ex.Data.Add("NIScode", value);
                    throw ex;
                }
                nIScode = value;
            } }
        public string Gemeentenaam { get; set; }

    }
}
