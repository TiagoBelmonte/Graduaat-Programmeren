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
    public class RunningSession_detailRepo : IRunningSession_detailRepo
    {
        private FitnessContext ctx;

        public RunningSession_detailRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }
        public List<Runningsession_detail> GetRunningSession_detail(int id)
        {
            List<RunningSessionDetailEF> runningSessionDetailEFs = ctx.runningsession_detail.Where(x => x.runningsession_id == id).AsNoTracking().ToList();
            List<Runningsession_detail> runningsession_Details = new List<Runningsession_detail>();
            try
            {
                foreach (RunningSessionDetailEF RSEF in runningSessionDetailEFs)
                {
                    runningsession_Details.Add(MapRunningSessionDetail.MapToDomain(RSEF));
                }
                return runningsession_Details;
            }
            catch (Exception)
            {
                throw new Exception("Runningsession_detailRepo - GetRunningSession_detail");
            }
        }
    }
}
