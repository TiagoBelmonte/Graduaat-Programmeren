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

        public ReservationEF(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId, EquipmentEF equipment, TimeSlotEF timeSlot, MemberEF member)
        {
            ReservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
            Equipment = equipment;
            TimeSlot = timeSlot;
            Member = member;
        }

        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public int TimeSlotId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        public EquipmentEF Equipment { get; set; }

        [ForeignKey(nameof(TimeSlotId))]
        public TimeSlotEF TimeSlot { get; set; }

        [ForeignKey(nameof(MemberId))]
        public MemberEF Member { get; set; }
    }

}
