using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Model;

namespace VisStatsBL.Interfaces
{
    public interface IVisStatsRepository
    {
        bool HeeftVissoort(Vissoort vis);
        bool HeeftHaven(Haven haven);

        bool isOpgeladen(string fileName);
        void SchrijfHaven(Haven haven);
        List<Haven> LeesHavens();
        List<Vissoort> LeesVissoorten();
        void SchrijfSoort(Vissoort vis);
        void SchrijfStatistieken(List<VisStatsDataRecord> data, string fileName);
        List<int> LeesJaartallen();
        List<Vissoort> GeefVissoorten();
        List<JaarVangst> LeesStatistieken(int jaar, Haven haven, List<Vissoort> vissoorten, Eenheid eenheid);
        MaandVangst LeesStatistiekenMaand(int jaren, List<Haven> havens, Eenheid eenheid, int maanden, Vissoort visSoort);
    }
}
