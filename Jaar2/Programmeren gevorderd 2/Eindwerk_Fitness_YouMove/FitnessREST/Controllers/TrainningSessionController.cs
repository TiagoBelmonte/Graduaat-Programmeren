using FitnessBL.Model;
using FitnessBL.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainningSessionController : ControllerBase
    {
        private readonly CyclingSessionService cyclingSessionService;
        private readonly RunningSession_mainService runningSessionService;
        private readonly RunningSession_detailService runningSessionDetailService;

        public TrainningSessionController(CyclingSessionService cyclingSessionService, RunningSession_mainService runningSessionService, RunningSession_detailService runningSessionDetailService)
        {
            this.cyclingSessionService = cyclingSessionService;
            this.runningSessionService = runningSessionService;
            this.runningSessionDetailService = runningSessionDetailService;
        }

        [HttpGet("/CyclingSessionOpvragenviaID/{id}")]
        public ActionResult<Cyclingsession> GetCyclingSession(int id)
        {
            try
            {
                Cyclingsession cyclingsession = cyclingSessionService.GetCyclingsession(id);
                if (cyclingsession == null)
                {
                    return NotFound("session niet gevonden");
                }

                CyclingSessionDTO DTO = new CyclingSessionDTO
                {
                    cyclingsession_id = cyclingsession.cyclingsession_id,
                    date = cyclingsession.date,
                    duration = cyclingsession.duration,
                    avg_watt = cyclingsession.avg_watt,
                    max_watt = cyclingsession.max_watt,
                    avg_cadence = cyclingsession.avg_cadence,
                    max_cadence = cyclingsession.max_cadence,
                    trainingtype = cyclingsession.trainingtype,
                    comment = cyclingsession.comment,
                    memberID = cyclingsession.memberID

                };
                return Ok(DTO);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/RunningSessionOpvragenMetDetails/{id}")]
        public ActionResult<object> GetRunningSessionWithDetails(int id)
        {
            try
            {
                // Haal de hoofdgegevens op
                Runningsession_main runningsession = runningSessionService.GetRunningSession_main(id);
                if (runningsession == null)
                {
                    return NotFound("Hoofdgegevens van de sessie niet gevonden");
                }

                // Converteer naar bestaand DTO
                RunningSession_mainDTO mainDTO = new RunningSession_mainDTO
                {
                    runningSession_id = runningsession.runningSession_id,
                    date = runningsession.date,
                    duration = runningsession.duration,
                    avg_speed = runningsession.avg_speed,
                    member_id = runningsession.member_id,
                };

                // Haal de details op
                List<Runningsession_detail> runningsessionDetails = runningSessionDetailService.GetRunningSession_detail(id);

                // Converteer naar bestaande detail-DTO's
                List<RunningSession_detailDTO> detailDTOs = new List<RunningSession_detailDTO>();
                if (runningsessionDetails != null)
                {
                    foreach (Runningsession_detail detail in runningsessionDetails)
                    {
                        RunningSession_detailDTO detailDTO = new RunningSession_detailDTO
                        {
                            seq_nr = detail.seq_nr,
                            runningsession_id = detail.runningsession_id,
                            interval_speed = detail.interval_speed,
                            interval_time = detail.interval_time,
                        };
                        detailDTOs.Add(detailDTO);
                    }
                }

                // Combineer de gegevens
                var combinedResult = new
                {
                    MainSession = mainDTO,
                    Details = detailDTOs
                };

                return Ok(combinedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
