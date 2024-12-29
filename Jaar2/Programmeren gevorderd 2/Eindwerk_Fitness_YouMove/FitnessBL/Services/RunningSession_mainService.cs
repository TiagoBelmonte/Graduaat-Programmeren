using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class RunningSession_mainService
    {
        private IRunningSession_mainRepo repo;

        public RunningSession_mainService(IRunningSession_mainRepo repo)
        {
            this.repo = repo;
        }

        public Runningsession_main GetRunningSession_main(int id)
        {
            try
            {
                return repo.Getrunningsession_Main(id);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRunningSession_main");
            }
        }

        public List<Runningsession_main> GetRunningSession_mainByMemberId(int id)
        {
            try
            {
                return repo.Getrunningsession_MainByMemberId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRunningSession_main");
            }
        }
    }
}
