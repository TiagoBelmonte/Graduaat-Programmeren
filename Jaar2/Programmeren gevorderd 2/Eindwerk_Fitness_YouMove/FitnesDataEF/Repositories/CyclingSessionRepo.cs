using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Repositories
{
    public class CyclingSessionRepo : ICyclingSession
    {

        private FitnessContext ctx;

        public CyclingSessionRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }

        public Cyclingsession GetCyclingSession(int sessionId)
        {
            try
            {
                CyclingSessionEF cyclingSessionEF = ctx.cyclingsession.FirstOrDefault(x => x.cyclingSession_id == sessionId);
                return MapCyclingSession.MapToDomain(cyclingSessionEF);
            }
            catch (Exception)
            {

                throw new Exception("CyclingSessionRepo - GetCyclingSession");
            }
        }

        //private void SaveAndClear()
        //{
        //    ctx.SaveChanges();
        //    ctx.ChangeTracker.Clear();
        //}


        public List<Cyclingsession> GetCyclingsSesions(int memberId)
        {
            List<Cyclingsession> sessions = new List<Cyclingsession>();
            List<CyclingSessionEF> cyclingSessionsEF = ctx.cyclingsession.Where(x => x.member_id == memberId).ToList();
            try
			{
                foreach (CyclingSessionEF C in cyclingSessionsEF)
                {
                    sessions.Add(MapCyclingSession.MapToDomain(C));
                }
                return sessions;
            }
			catch (Exception)
			{

				throw new Exception("CyclingSessionRepo - GetCyclingsSesions");
			}
        }
    }
}
