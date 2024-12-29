using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Repositories
{
    public class Runningsession_mainRepo : IRunningSession_mainRepo
    {
        private FitnessContext ctx;

        public Runningsession_mainRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }

        public Runningsession_main Getrunningsession_Main(int id)
        {
            try
            {
                return MapRunningSessionMain.MapToDomain(ctx.runningSession_main.Where(x => x.runningSession_id == id).AsNoTracking().FirstOrDefault());
            }
            catch (Exception)
            {

                throw new Exception("Runningsession_mainRepo - Getrunningsession_Main");
            }
            
        }

        public List<Runningsession_main> Getrunningsession_MainByMemberId(int id)
        {
            try
            {
                List<RunningSessionMainEF> sessionsEF = ctx.runningSession_main.Where(x => x.member_id == id).AsNoTracking().ToList();
                List<Runningsession_main> sessions = new List<Runningsession_main>();
                foreach (RunningSessionMainEF s in sessionsEF)
                {
                    sessions.Add(MapRunningSessionMain.MapToDomain(s));
                }
                return sessions;
            }
            catch (Exception)
            {
                throw new Exception("Runningsession_mainRepo - Getrunningsession_MainByMemberId");
            }
        }
    }
}
