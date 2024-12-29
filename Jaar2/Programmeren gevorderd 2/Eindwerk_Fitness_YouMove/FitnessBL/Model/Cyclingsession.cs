using FitnessBL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Cyclingsession
    {
        public int cyclingsession_id { get; set; }
        public DateTime date { get; set; }
        public int duration { get; set; }
        public int avg_watt { get; set; }
        public int max_watt { get; set; }
        public int avg_cadence { get; set; }
        public int max_cadence { get; set; }
        public Trainingtype trainingtype { get; set; } // Enum in plaats van string
        public string? comment { get; set; }
        public Member member { get; set; }
        public int memberID { get; set; }

        public Cyclingsession(
            int id,
            DateTime date,
            int duration,
            int avg_watt,
            int max_watt,
            int avg_cadence,
            int max_cadence,
            Trainingtype trainingtype, // Parameter aangepast naar Trainingtype
            string? comment,
            Member member)
        {
            cyclingsession_id = id;
            this.date = date;
            this.duration = duration;
            this.avg_watt = avg_watt;
            this.max_watt = max_watt; // Fix voor dubbele toewijzing
            this.avg_cadence = avg_cadence;
            this.max_cadence = max_cadence;
            this.trainingtype = trainingtype;
            this.comment = comment;
            this.member = member;
        }

        public Cyclingsession(
            int id,
            DateTime date,
            int duration,
            int avg_watt,
            int max_watt,
            int avg_cadence,
            int max_cadence,
            Trainingtype trainingtype, // Parameter aangepast naar Trainingtype
            string? comment,
            int memberid)
        {
            cyclingsession_id = id;
            this.date = date;
            this.duration = duration;
            this.avg_watt = avg_watt;
            this.max_watt = max_watt; // Fix voor dubbele toewijzing
            this.avg_cadence = avg_cadence;
            this.max_cadence = max_cadence;
            this.trainingtype = trainingtype;
            this.comment = comment;
            memberid = memberID;
        }
    }
}
