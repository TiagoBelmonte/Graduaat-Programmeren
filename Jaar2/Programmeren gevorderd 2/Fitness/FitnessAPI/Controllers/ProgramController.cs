using FitnessAPI.DTO;
using FitnessBL.Enums;
using FitnessBL.Exceptions;
using FitnessBL.Model;
using FitnessBL.Services;
using Microsoft.AspNetCore.Mvc;
using ProgramBL = FitnessBL.Model.Program;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private ProgramService programService;

        public ProgramController(ProgramService programService)
        {
            this.programService = programService;
        }

        [HttpGet("/ProgrammaViaProgramCode/{programCode}")]
        public IActionResult GetProgramCode(string programCode)
        {
            try
            {
                ProgramBL program = programService.GetProgramCode(programCode);
                return Ok(program);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Programma")]
        public IActionResult AddProgram([FromBody] ProgramAanmakenDTO programDTO)
        {
            try
            {
                ProgramBL program = new ProgramBL(
                    programDTO.ProgramCode,
                    programDTO.Name,
                    programDTO.Target,
                    (DateTime)programDTO.Startdate,
                    (int)programDTO.Max_members
                );

                programService.AddProgram(program);

                return CreatedAtAction(
                    nameof(GetProgramCode), // Specify the action name of the "Get" endpoint
                    new { programCode = program.ProgramCode }, // Parameter voor de Get eindpoint
                    program // Return the created gebruiker object
                );
            }
            catch (ProgramException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("/Programma/{programCode}")]
        public IActionResult UpdateProgram(
    string programCode,
    [FromBody] ProgramAanmakenDTO updateRequest
)
        {
            try
            {
                // Haal het programma op uit de database
                ProgramBL program = programService.GetProgramCode(programCode);

                // Pas alleen de velden aan die niet null zijn
                if (!string.IsNullOrEmpty(updateRequest.Name))
                    program.Name = updateRequest.Name;
                if (!string.IsNullOrEmpty(updateRequest.Target))
                    program.Target = updateRequest.Target;
                if (updateRequest.Startdate.HasValue)
                    program.Startdate = updateRequest.Startdate.Value;
                if (updateRequest.Max_members.HasValue)
                    program.Max_members = updateRequest.Max_members.Value;

                // Update het record in de database
                programService.UpdateProgram(program);

                return CreatedAtAction(
                    nameof(GetProgramCode),
                    new { programCode = program.ProgramCode },
                    program
                );
            }
            catch (ProgramException ex)
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
