using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IProgramRepo
    {
        Program addProgram(Program program);
        Program GetProgram(string id);
        void updateProgram(Program program);
    }
}
