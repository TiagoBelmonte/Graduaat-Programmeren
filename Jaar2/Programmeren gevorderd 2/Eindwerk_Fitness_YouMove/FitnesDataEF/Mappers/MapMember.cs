using FitnesDataEF.Model;
using FitnessBL.Enum;
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
                // Convert string to enum
                KlantType klantType = Enum.Parse<KlantType>(db.membertype, true);

                // Convert comma-separated string to list or return empty list if NULL
                List<string> interests = string.IsNullOrEmpty(db.interests)
                    ? new List<string>()
                    : db.interests.Split(',').ToList();

                return new Member(
                    db.member_id,
                    db.first_name,
                    db.last_name,
                    db.email,
                    db.address,
                    db.birthday,
                    klantType,
                    interests
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping MemberEF to Member domain model.", ex);
            }

        }

        public static MemberEF MapToDB(Member m)
        {
            try
            {
                // Convert enum to string
                string klantType = m.membertype.ToString();
                // Convert list to comma-separated string
                string interests = m.interests == null
                    ? null
                    : string.Join(",", m.interests);
                return new MemberEF(
                    m.member_id,
                    m.first_name,
                    m.last_name,
                    m.email,
                    m.address,
                    m.birthday,
                    interests,
                    klantType,
                    null,
                    null,
                    null,
                    null
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping Member m model to MemberEF.", ex);
            }
        }

    }
}
