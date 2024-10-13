using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisStatsBL.Model;

namespace VisStatsBL.Interfaces
{
    public interface IFileProcessor
    {
        public List<string> LeesSoorten(string fileName);
        public List<string> LeesHavens(string fileName);
    
        List<VisStatsDataRecord> LeesStatistieken(string fileName, List<Vissoort> soorten, List<Haven> havens);
    }
}
