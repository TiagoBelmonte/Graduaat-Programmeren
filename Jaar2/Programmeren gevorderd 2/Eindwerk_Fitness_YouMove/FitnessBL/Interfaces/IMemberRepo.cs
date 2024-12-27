using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IMemberRepo
    {
        Member GetMember(int id);
        Member AddMember(Member member);
        void UpdateMember(Member member);
    }
}
