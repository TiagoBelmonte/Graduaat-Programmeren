using FitnesDataEF.Model;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Mappers
{
    public class MapMember
    {
        public static Member MapToDomain(MemberEF db)
        {
			try
			{
				return new Member(db.first_name, db.last_name, db.email, db.address, db.birthday);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
