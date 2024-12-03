using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Tijdslot
    {
        // Eigenschappen
        public int Id { get; set; }
        public int StartUur { get; set; }
        public int EindUur { get; set; }
        public string DagDeel { get; set; }

        // Constructor
        public Tijdslot(int id, int startUur, int eindUur, string dagDeel)
        {
            Id = id;
            StartUur = startUur;
            EindUur = eindUur;
            DagDeel = dagDeel;
        }

        // Optionele override van ToString() om het tijdslot gemakkelijk te tonen
        public override string ToString()
        {
            return $"Tijdslot {Id}: {StartUur}:00 - {EindUur}:00 ({DagDeel})";
        }
    }

}
