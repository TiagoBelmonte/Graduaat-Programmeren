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
    public class ReservationRepo : IReservationRepo
    {
        private readonly FitnessContext ctx;
        private MapReservation map = new MapReservation();

        public ReservationRepo(String connectionString)
        {
            this.ctx = new FitnessContext(connectionString);
        }
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }
        public void AddReservation(Reservation reservation)
        {
            var reservationEFs = MapReservation.MapToDB(reservation);
            foreach (var reservationEF in reservationEFs)
            {
                ctx.reservation.Add(reservationEF);
            }
            SaveAndClear();
        }

        public void DeleteReservation(int id)
        {
            try
            {
                List<ReservationEF> reservations = ctx.reservation
                    .Where(r => r.reservation_id == id)
                    .ToList();

                if (!reservations.Any())
                    throw new Exception($"Geen reservaties gevonden met ID {id}.");

                foreach (var reservation in reservations)
                {
                    ctx.reservation.Remove(reservation);
                }
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationRepo - DeleteReservation", ex);
            }
        }

        // GetReservationsById
        public List<Reservation> GetReservationsById(int id)
        {
            try
            {
                List<ReservationEF> reservationEFs = ctx.reservation
                    .Where(r => r.reservation_id == id)
                    .ToList();

                if (!reservationEFs.Any())
                    throw new Exception($"Geen reservaties gevonden met ID {id}.");

                //// Map alle gevonden ReservationEFs naar Reservation
                //return reservationEFs.Select(reservationEF =>
                //    map.MapToDomain(
                //        reservationEF,
                //        ctx.time_slots.ToList(),
                //        ctx.equipments.ToList(),
                //        ctx.members.ToList()
                //    )).ToList();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationRepo - GetReservationsById", ex);
            }
        }

        public List<Reservation> GetReservationsByMember(int memberid)
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
              List<ReservationEF> reservationEFs = ctx.reservation
                    .Where(r => r.member_id == memberid)
                    .ToList();
                if (!reservationEFs.Any())
                    throw new Exception($"Geen reservaties gevonden voor lid met ID {memberid}.");
                // Map alle gevonden ReservationEFs naar Reservation
                foreach (ReservationEF REF in reservationEFs)
                {
                    EquipmentEF equipmentEF = ctx.equipment
                        .Where(e => e.equipment_id == REF.equipment_id)
                        .FirstOrDefault();
                    MemberEF memberEF = ctx.members
                        .Where(m => m.member_id == memberid)
                        .FirstOrDefault();
                    TimeSlotEF timeSlotEF = ctx.time_slot
                        .Where(t => t.time_slot_id == REF.time_slot_id)
                        .FirstOrDefault();
                    
                    REF.members = memberEF;
                    REF.timeslot = timeSlotEF;
                    REF.equipment = equipmentEF;
                    reservations.Add(MapReservation.MapToDomain(REF));
                }
                return reservations;
            }
            catch (Exception)
            {
                throw new Exception("ReservationRepo - GetReservationsByMemberID");
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public int GetNieuwReservationId()
        {
            try
            {
                int hoogstBestaandId = ctx.reservation.Max(r => r.reservation_id);
                return hoogstBestaandId + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationRepo - GetNieuwReservationId");
            }
        }

        public Reservation GetReservationId(int id)
        {
            try
            {
                var reservationEF = ctx.reservation
                    .Where(r => r.reservation_id == id)
                    .Include(m => m.members)
                    .Include(e => e.equipment)
                    .Include(t => t.timeslot)
                    .AsNoTracking()
                    .FirstOrDefault();

                if (reservationEF == null)
                {
                    throw new Exception($"Geen reservatie gevonden met ID {id}.");
                }

                // Map de gevonden ReservationEF naar een Reservation
                return MapReservation.MapToDomain(reservationEF);
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationRepo - GetReservationById", ex);
            }
        }
    }
}
