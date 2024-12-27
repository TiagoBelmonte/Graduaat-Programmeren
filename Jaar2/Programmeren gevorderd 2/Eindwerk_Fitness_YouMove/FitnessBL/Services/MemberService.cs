using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class MemberService
    {
        private IMemberRepo repo;

        public MemberService(IMemberRepo repo)
        {
            this.repo = repo;
        }

        public Member GetMember(int id)
        {
            try
            {
                return repo.GetMember(id);
            }
            catch (Exception ex)
            {

                throw new Exception("getMember");
            }
        }

        public Member AddMember(Member member)
        {
            try
            {
                return repo.AddMember(member);
            }
            catch (Exception ex)
            {
                throw new Exception("AddMember");
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                repo.UpdateMember(member);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateMember");
            }
        }
    }
}
