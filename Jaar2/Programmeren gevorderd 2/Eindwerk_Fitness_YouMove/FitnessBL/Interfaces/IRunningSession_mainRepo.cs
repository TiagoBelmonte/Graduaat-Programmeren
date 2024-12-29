using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IRunningSession_mainRepo
    {
        Runningsession_main Getrunningsession_Main(int id);
        List<Runningsession_main> Getrunningsession_MainByMemberId(int id);
    }
}
