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
    public class ProgramRepo : IProgramRepo
    {
        private FitnessContext ctx;

        public ProgramRepo(string connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }


        public Program GetProgram(String id)
        {


            return MapProgram.MapToDomain(ctx.program.Where(x => x.programCode.Equals(id)).AsNoTracking().FirstOrDefault());

        }

        public Program addProgram(Program program)
        {
            try
            {
                ProgramEF p = MapProgram.mapToDB(program);
                ctx.program.Add(p);
                SaveAndClear();
                return program;

            }
            catch (Exception)
            {

                throw new Exception("ProgramRepo - addProgram");
            }
        }

        public void updateProgram(Program program)
        {
            try
            {
                ctx.program.Update(MapProgram.mapToDB(program));
                SaveAndClear();
            }
            catch (Exception)
            {

                throw new Exception("ProgramRepo - updateEquipment");
            }
        }

    }
}
