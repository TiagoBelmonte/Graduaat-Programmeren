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
    public class MapCyclingSession
    {
        public static Cyclingsession MapToDomain(CyclingSessionEF db)
        {
            try
            {
                // Convert db.trainingtype from string to Trainingtype enum
                Trainingtype trainingTypeEnum = Enum.Parse<Trainingtype>(db.trainingtype);

                return new Cyclingsession(db.cyclingSession_id, db.date, db.duration, db.avg_watt, db.max_watt, db.avg_cadence, db.max_cadence, trainingTypeEnum, db.comment, MapMember.MapToDomain(db.members));
            }
            catch (Exception)
            {
                throw new Exception("MapEquipment - mapToDomain");
            }
        }

        public static CyclingSessionEF mapToDB(Cyclingsession C)
        {
            try
            {
                return new CyclingSessionEF
                {
                    cyclingSession_id = C.cyclingsession_id,
                    date = C.date,
                    duration = C.duration,
                    avg_watt = C.avg_watt,
                    max_watt = C.max_watt,
                    avg_cadence = C.avg_cadence,
                    max_cadence = C.max_cadence,
                    trainingtype = C.trainingtype.ToString(),
                    comment = C.comment,
                    member_id = (int)C.member.member_id,
                    members = new MemberEF
                    {
                        member_id = C.member.member_id,
                        first_name = C.member.first_name,
                        last_name = C.member.last_name,
                        email = C.member.email,
                        address = C.member.address,
                        birthday = C.member.birthday,
                        membertype = C.member.membertype.ToString(),
                        interests = string.Join(",", C.member.interests)
                    }
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error mapping CyclingSession E model to EquipmentEF.", ex);
            }
        }
    }
}
