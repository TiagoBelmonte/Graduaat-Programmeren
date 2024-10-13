using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStatsBL.Model
{
    public class MaandVangst
    {
        public double Totaal { get; set; }
        public int Jaar { get; set; }
        public int Maand { get; set; }
        public string havens { get; set; }

        public MaandVangst(double totaal, int jaar, int maand, string havens)
        {
            Jaar = jaar;
            Totaal = totaal;
            Maand = maand;
            this.havens = havens;
        }

        public override string? ToString()
        {
            return havens.ToString();
        }
    }
}
