using FitnessBL.Exceptions;
using FitnessBL.Model;
using FitnessBL.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly EquipmentService equipmentService;
        private readonly ReservationService reservationService;
        private readonly Time_slotService timeSlotService;
        private readonly MemberService memberService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet("/ReservationViaId/{id}")]
        public IActionResult GetReservationID(int id)
        {
            try
            {
                Reservation reservation = reservationService.GetReservationId(id);
                return Ok(reservation);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPost("/ReservationToevoegen")]
        public IActionResult CreateReservation([FromBody] ReservationDTO reservationDTO)
        {
            try
            {
                Dictionary<Time_slot, Equipment> dic = new Dictionary<Time_slot, Equipment>();
                foreach (TimeSlotEquipmentDTO tseDTO in reservationDTO.EquipmentPerTimeslot)
                {
                    Time_slot ts = timeSlotService.GetTime_slotId(tseDTO.Time_slot_id);
                    Equipment e = equipmentService.GetEquipmentId(tseDTO.Equipment_id);
                    dic.Add(ts, e);
                }

                Member member = memberService.GetMember(reservationDTO.MemberId);

                Reservation reservation = new Reservation(
                    reservationService.GetNieuwReservationId(),
                    dic,
                    member,
                    reservationDTO.Date
                );

                reservationService.AddReservation(reservation);

                return CreatedAtAction(
                    nameof(GetReservationID),
                    new { id = reservation.ReservationId },
                    reservation
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
