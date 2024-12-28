using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapProgram
    {
        public static Program MapToDomain(ProgramEF db)
        {
            try
            {
                return new Program(db.programCode,db.name,db.target,db.startdate,db.max_members,null);
            }
            catch (Exception)
            {

                throw new Exception("MapProgram - mapToDomain");
            }

        }

        public static ProgramEF mapToDB(Program P)
        {
            try
            {
                return new ProgramEF(P.programCode,P.name,P.target,P.startDate,P.max_members,null);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Program P model to ProgramEF.", ex);
            }
        }
    }
}
