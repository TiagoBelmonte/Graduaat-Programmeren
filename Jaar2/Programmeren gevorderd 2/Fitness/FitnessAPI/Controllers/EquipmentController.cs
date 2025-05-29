using FitnessAPI.DTO;
using FitnessBL.Enums;
using FitnessBL.Exceptions;
using FitnessBL.Model;
using FitnessBL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private EquipmentService equipmentService;
        private ReservationService reservationService;

        public EquipmentController(
            EquipmentService equipmentService,
            ReservationService reservationService
        )
        {
            this.equipmentService = equipmentService;
            this.reservationService = reservationService;
        }

        [HttpGet("/EquipmentViaId/{id}")]
        public IActionResult GetEquipmentId(int id)
        {
            try
            {
                Equipment equipment = equipmentService.GetEquipmentId(id);

                return Ok(equipment);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Equipment")]
        public IActionResult AddEquipment([FromBody] EquipmentAanmakenDTO equipmentDTO)
        {
            try
            {
                Equipment equipment = new Equipment(equipmentDTO.device_type);
                equipmentService.AddEquipment(equipment);

                return CreatedAtAction(
                    nameof(GetEquipmentId), // Specify the action name of the "Get" endpoint
                    new { id = equipment.Equipment_id }, // Parameter voor de Get eindpoint
                    equipment // Return the created gebruiker object
                );
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/EquipmenViaId/{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            try
            {
                Equipment equipment = equipmentService.GetEquipmentId(id);
                equipmentService.DeleteEquipment(equipment);
                return Ok($"Equipment met id {id} is succesvol verwijderd!");
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/EquipmentInOnderhoud")]
        public IActionResult EquipmentPlaatsOnderhoud(
            [FromBody] int equipmentid
        )
        {
            using (var transaction = equipmentService.equipmentRepo.BeginTransaction()) // Start de transactie
            {
                try
                {
                    Equipment equipment = equipmentService.GetEquipmentId(
                        equipmentid
                    );

                    reservationService.UpdateReservationsWithNewEquipment(equipment);
                    equipmentService.EquipmentPlaatsOnderhoud(equipment);
                    transaction.Commit();
                    return Ok(
                        $"Equipment met id {equipmentid} is succesvol in onderhoud geplaatst!"
                    );
                }
                catch (ServiceException ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("/EquipmentUitOnderhoud")]
        public IActionResult EquipmentVerwijderOnderhoud(
            [FromBody] int equipmentid
        )
        {
            try
            {
                Equipment equipment = equipmentService.GetEquipmentId(
                    equipmentid
                );
                equipmentService.EquipmentVerwijderOnderhoud(equipment, DateTime.Now);
                return Ok(
                    $"Equipment met id {equipmentid} is succesvol uit onderhoud verwijderd!"
                );
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/AllAvailableEquipment/{dateAsString}/{timeSlotId}")]
        public IActionResult GetAllAvailableEquipment(string dateAsString, int timeSlotId)
        {
            try
            {
                DateTime date = DateTime.Parse(dateAsString);
                IEnumerable<Equipment> availableEquipments =
                    equipmentService.GetAllAvailableEquipment(date, timeSlotId);
                return Ok(availableEquipments);
            }
            catch (FormatException ex)
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
