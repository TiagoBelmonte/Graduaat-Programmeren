using FitnesDataEF.Exceptions;
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
    public class MemberRepo : IMemberRepo
    {
        private FitnessContext ctx;

        public MemberRepo(string connectionString)
        { 
            this.ctx = new FitnessContext(connectionString);
        }
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public Member AddMember(Member member)
        {
            try
            {
                MemberEF m = MapMember.MapToDB(member);
                ctx.members.Add(m);
                SaveAndClear();
                member.member_id = m.member_id;
                return member;
            }
            catch (Exception ex)
            {

                throw new Exception ("MemberRepo - AddMember");
            }
        }

        public Member GetMember(int id)
        {


            return MapMember.MapToDomain(ctx.members.Where(x => x.member_id == id).AsNoTracking().FirstOrDefault());

        }

        public void UpdateMember(Member member)
        {
            try
            {
                ctx.members.Update(MapMember.MapToDB(member));
                SaveAndClear();
            }
            catch (Exception)
            {

                throw new Exception("MemberRepo - UpdateMember");
            }
        }
    }
}
