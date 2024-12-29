using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class RunningSession_detailService
    {
        private IRunningSession_detailRepo repo;

        public RunningSession_detailService(IRunningSession_detailRepo repo)
        {
            this.repo = repo;
        }

        public List<Runningsession_detail> GetRunningSession_detail(int id)
        {
            try
            {
                return repo.GetRunningSession_detail(id);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRunningSession_main");
            }
        }
    }
}
