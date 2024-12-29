using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Runningsession_detail
    {
        public int seq_nr {  get; set; }
        public Runningsession_main runningsession { get; set; }
        public int runningsession_id { get; set; }
        public int interval_time { get; set; }
        public decimal interval_speed { get; set; }

        public Runningsession_detail (int seq_nr, Runningsession_main runningsession, int interval_time, decimal interval_speed)
        {
            this.seq_nr = seq_nr;
            this.runningsession = runningsession;
            this.interval_time = interval_time;
            this.interval_speed = interval_speed;
        }

        public Runningsession_detail(int seq_nr, int runningsessionid, int interval_time, decimal interval_speed)
        {
            this.seq_nr = seq_nr;
            runningsession_id = runningsessionid;
            this.interval_time = interval_time;
            this.interval_speed = interval_speed;
        }

        public Runningsession_detail()
        {
        }
    }
}
