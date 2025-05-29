﻿using System.ComponentModel.DataAnnotations;
using FitnessAPI.DTO;
using FitnessBL.Exceptions;
using FitnessBL.Model;
using FitnessBL.Services;
using FitnessEF.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private ReservationService reservationService;
        private MemberService memberService;
        private EquipmentService equipmentService;
        private Time_slotService timeSlotService;

        public ReservationController(
            ReservationService reservationService,
            MemberService memberService,
            EquipmentService equipmentService,
            Time_slotService timeSlotService
        )
        {
            this.reservationService = reservationService;
            this.memberService = memberService;
            this.equipmentService = equipmentService;
            this.timeSlotService = timeSlotService;
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

        [HttpPost("/Reservation")]
        public IActionResult CreateReservation([FromBody] ReservationAanmakenDTO reservationDTO)
        {
            try
            {
                Dictionary<Time_slot, Equipment> dic = new Dictionary<Time_slot, Equipment>();
                foreach (TimeslotEquipmentDTO tseDTO in reservationDTO.EquipmentPerTimeslot)
                {
                    Time_slot ts = timeSlotService.GetTime_slotId(tseDTO.Time_slot_id);
                    Equipment e = equipmentService.GetEquipmentId(tseDTO.Equipment_id);
                    dic.Add(ts, e);
                }

                Member member = memberService.GetMemberId(reservationDTO.MemberId);

                Reservation reservation = new Reservation(
                    reservationService.GetNieuwReservationId(),
                    reservationDTO.Date,
                    member,
                    dic
                );

                reservationService.AddReservation(reservation);

                return CreatedAtAction(
                    nameof(GetReservationID),
                    new { id = reservation.Reservation_id },
                    reservation
                );
            }
            catch (ReservationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Time_SlotException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RepoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("/Reservation/{id}")]
        public IActionResult UpdateReservationTimeSlots(
    int id,
    [FromBody] ReservationAanpassenDTO reservationAanpassenDTO
)
        {
            try
            {
                // Haal de bestaande reservatie op
                Reservation reservation = reservationService.GetReservationId(id);

                // Maak een nieuwe dictionary voor Time_slots en Equipment
                Dictionary<Time_slot, Equipment> dic = new Dictionary<Time_slot, Equipment>();
                foreach (TimeslotEquipmentDTO tseDTO in reservationAanpassenDTO.TimeslotEquipment)
                {
                    Time_slot ts = timeSlotService.GetTime_slotId(tseDTO.Time_slot_id);
                    Equipment e = equipmentService.GetEquipmentId(tseDTO.Equipment_id);
                    dic.Add(ts, e);
                }

                // Maak een nieuwe geüpdatete reservatie
                Reservation geupdateReservation = new Reservation(
                    reservation.Reservation_id,
                    reservation.Date,
                    reservation.Member,
                    dic
                );

                // Werk de reservatie bij
                reservationService.UpdateReservationTimeSlots(reservation, geupdateReservation);

                return CreatedAtAction(
                    nameof(GetReservationID),
                    new { id = geupdateReservation.Reservation_id },
                    geupdateReservation
                );
            }
            catch (ReservationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/Reservation/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            try
            {
                Reservation reservation = reservationService.GetReservationId(id);
                reservationService.DeleteReservation(reservation);
                return Ok("De reservation is succesvol verwijderd!");
            }
            catch (RepoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
