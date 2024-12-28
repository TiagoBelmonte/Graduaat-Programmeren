using FitnesDataEF.Mappers;
using FitnesDataEF.Model;
using FitnessBL.Interfaces;
using FitnessBL.Model;
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
            throw new NotImplementedException();
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

        public List<Reservation> GetReservationsByMember(int member_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
