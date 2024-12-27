using FitnesDataEF.Exceptions;
using FitnesDataEF.Mappers;
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
    public class MemberRepo : IMemberRepo
    {
        private FitnessContext ctx;

        public MemberRepo(string connectionString)
        { 
            this.ctx = new FitnessContext(connectionString);
        }


        public Member GetMember(int id)
        {


            return MapMember.MapToDomain(ctx.members.Where(x => x.member_id == id).AsNoTracking().FirstOrDefault());

        }
    }
}
