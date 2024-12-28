using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class ReservationEF
    {
        public ReservationEF()
        {
        }

        public ReservationEF(int reservationId, int equipmentId, int timeSlotId, DateTime Date, int memberId, EquipmentEF Equipment, TimeSlotEF TimeSlot, MemberEF Member)
        {
            reservation_id = reservationId;
            equipment_id = equipmentId;
            time_slot_id = timeSlotId;
            date = Date;
            member_id = memberId;
            equipment = Equipment;
            timeslot = TimeSlot;
            members = Member;
        }

        public ReservationEF(int reservationId, int equipmentId, int timeSlotId, DateTime Date, int memberId)
        {
            reservation_id = reservationId;
            equipment_id = equipmentId;
            time_slot_id = timeSlotId;
            date = Date;
            member_id = memberId;
        }

        [Key]
        public int reservation_id { get; set; }

        [Required]
        public int equipment_id { get; set; }

        [Required]
        public int time_slot_id { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int member_id { get; set; }

        [ForeignKey(nameof(equipment_id))]
        public EquipmentEF equipment { get; set; }

        [ForeignKey(nameof(time_slot_id))]
        public TimeSlotEF timeslot { get; set; }

        [ForeignKey(nameof(member_id))]
        public MemberEF members { get; set; }
    }

}
