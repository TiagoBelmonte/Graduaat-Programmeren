using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Runningsession_main
    {
        public int? runningSession_id {  get; set; }
        public DateTime date { get; set; }
        public Member member { get; set; }
        public int duration { get; set; }
        public int avg_speed { get; set; }

        public Runningsession_main(int? id, DateTime date, Member member, int duration, int avgspeed)
        {
            runningSession_id = id;
            this.date = date;
            this.member = member;
            this.duration = duration;
            avg_speed = avgspeed;
        }
    }
}
