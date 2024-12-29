using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class CyclingSessionService
    {
        private ICyclingSession repo;

        public CyclingSessionService(ICyclingSession repo)
        {
            this.repo = repo;
        }

        public List<Cyclingsession> GetCyclingSessions(int memberId)
        {
            try
            {
                return repo.GetCyclingsSesions(memberId);
            }
            catch (Exception ex)
            {
                throw new Exception("GetCyclingSessions");
            }
        }

        public Cyclingsession GetCyclingsession(int sessionID)
        {
            try
            {
                return repo.GetCyclingSession(sessionID);
            }
            catch (Exception)
            {

                throw new Exception("GetCyclingSession");
            }
        }
    }
}
