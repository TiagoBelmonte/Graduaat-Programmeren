using FitnessBL.Interfaces;
using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class ReservationService
    {
        private IReservationRepo repo;

        public ReservationService(IReservationRepo repo)
        {
            this.repo = repo;
        }

        public void AddReservation(Reservation reservation)
        {
            try
            {
                repo.AddReservation(reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("AddReservation");
            }
        }
        public void RemoveReservation(int id)
        {
            try
            {
                repo.DeleteReservation(id);
            }
            catch (Exception ex)
            {
                throw new Exception("RemoveReservation");
            }
        }

        public List<Reservation> getReservationsByMemberID(int id)
        {
            try
            {
                return repo.GetReservationsByMember(id);
            }
            catch (Exception)
            {

                throw new Exception("getReservationsByMemberID");
            }
        }
    }
}
