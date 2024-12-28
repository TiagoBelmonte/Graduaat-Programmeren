using FitnessBL.Model;
using FitnessBL.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentService equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }



        [HttpPost("/ToestelToevoegen")]
        public ActionResult<Equipment> AddEquipment([FromBody] EquipmentDTO equipmentDTO)
        {
            try
            {
                Equipment equipment = new Equipment(
                    default(int?),
                    equipmentDTO.device_type,
                    false
                );

                equipment = equipmentService.AddEquipment(equipment);
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("/ToestelInOnderhoudPlaatsen/{id}")]
        public ActionResult<Equipment> UpdateEquipment(int id)
        {
            try
            {
                equipmentService.updateEquipment(id);
                return Ok("Toestel in onderhoud geplaatst");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
