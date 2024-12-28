using FitnessBL.Model;
using FitnessBL.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly ProgramService programService;

        public ProgramController(ProgramService programService)
        {
            this.programService = programService;
        }

        [HttpPost("/ProgrammaToevoegen")]
        public ActionResult<ProgramREST> AddProgram([FromBody] ProgramDTO programDTO)
        {
            try
            {
                Program program = new Program(
                    programDTO.programCode,
                    programDTO.name,
                    programDTO.target,
                    programDTO.startDate,
                    programDTO.max_members,
                    programDTO.Members
                );

                program = programService.AddProgram(program);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("/ProgramUpdaten/{id}")]
        public IActionResult updateProgram(
    string id,
    [FromQuery] string name = null,
    [FromQuery] string target = null,
    [FromQuery] DateTime? startDate = null,
    [FromQuery] int? maxMembers = null,
    [FromQuery] List<Member> members = null
)
        {
            try
            {
                // Haal het Program op uit de database
                Program program = programService.GetProgram(id);
                if (program == null)
                {
                    return NotFound("Programma niet gevonden");
                }

                // Pas alleen de velden aan die zijn meegegeven (niet null)
                if (!string.IsNullOrEmpty(name))
                    program.name = name;
                if (!string.IsNullOrEmpty(target))
                    program.target = target;
                if (startDate.HasValue)
                {
                    if (startDate.Value < DateTime.Now)
                        return BadRequest("Startdatum mag niet in het verleden liggen.");
                    program.startDate = startDate.Value;
                }
                if (maxMembers.HasValue)
                {
                    if (maxMembers.Value <= 0)
                        return BadRequest("Maximaal aantal leden moet groter zijn dan 0.");
                    program.max_members = maxMembers.Value;
                }
                if (members != null)
                    program.Members = members;

                // Update het record in de database
                programService.updateProgram(program);

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Er is een fout opgetreden: {ex.Message}");
            }
        }


    }
}
