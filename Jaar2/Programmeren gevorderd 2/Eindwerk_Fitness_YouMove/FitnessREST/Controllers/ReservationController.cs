using FitnessBL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
            
        private readonly ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }


        [HttpDelete("/ReservationVerwijderen/{id}")]
        public ActionResult DeleteReservation(int id)
        {
            try
            {
                reservationService.RemoveReservation(id);
                return Ok("Reservatie verwijderd");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
