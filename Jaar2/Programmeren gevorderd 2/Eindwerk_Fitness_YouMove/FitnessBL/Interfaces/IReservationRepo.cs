using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IReservationRepo
    {
        void AddReservation(Reservation reservation);
        void DeleteReservation(int reservationID);
        void UpdateReservation(Reservation reservation);
        List<Reservation> GetReservationsById(int id);
        List<Reservation> GetReservationsByMember(int member_id);
    }
}
