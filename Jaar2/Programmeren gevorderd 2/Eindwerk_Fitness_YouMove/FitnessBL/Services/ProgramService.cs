using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class ProgramService
    {
        private IProgramRepo repo;

        public ProgramService(IProgramRepo repo)
        {
            this.repo = repo;
        }


        public Program GetProgram(string id)
        {
            try
            {
                return repo.GetProgram(id);
            }
            catch (Exception ex)
            {

                throw new Exception("getProgram");
            }
        }
        public Program AddProgram(Program program)
        {
            try
            {
                return repo.addProgram(program);
            }
            catch (Exception ex)
            {
                throw new Exception("AddProgram");
            }
        }

        public void updateProgram(Program program)
        {
            try
            {
                repo.updateProgram(program);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateProgram");
            }
        }

    
    }
}
