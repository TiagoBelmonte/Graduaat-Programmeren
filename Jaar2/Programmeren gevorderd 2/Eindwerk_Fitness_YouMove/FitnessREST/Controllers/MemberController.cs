using FitnessBL.Model;
using FitnessBL.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService memberService;
        private readonly ProgramMembersService programMembersService;
        private  readonly CyclingSessionService cyclingSessionService;
        private readonly RunningSession_mainService runningSession_MainService;
        private readonly ReservationService reservationService;

        public MemberController(MemberService memberService, ProgramMembersService programMembersService, CyclingSessionService cyclingSessionService, RunningSession_mainService runningSession_MainService, ReservationService reservationService)
        {
            this.memberService = memberService;
            this.programMembersService = programMembersService;
            this.cyclingSessionService = cyclingSessionService;
            this.runningSession_MainService = runningSession_MainService;
            this.reservationService = reservationService;
        }

        [HttpGet("/AlgemeneGegevensGebruikerOpzoekenViaId/{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            try
            {
                Member member = memberService.GetMember(id);
                if (member == null)
                { 
                    return NotFound("Gebruiker niet gevonden");
                }

                MemberDTO memberDTO = new MemberDTO
                { 
                    member_id = member.member_id,
                    first_name = member.first_name,
                    last_name = member.last_name,
                    email = member.email,
                    address = member.address,
                    birthday = member.birthday,
                    interests = member.interests,
                    memberType = member.membertype
                };
                return Ok(memberDTO);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/GebruikerToevoegen")]
        public ActionResult<Member> AddMember([FromBody] MemberDTO memberDTO)
        {
            try
            {
                // Assuming the member_id is auto-generated, you can pass null or default value
                Member member = new Member(
                    null, // or default(int?)
                    memberDTO.first_name,
                    memberDTO.last_name,
                    memberDTO.email,
                    memberDTO.address,
                    memberDTO.birthday,
                    memberDTO.memberType,
                    memberDTO.interests
                );

                member = memberService.AddMember(member);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("/GebruikergegevensUpdaten/{id}")]
        public IActionResult updateMember(
            int id,
            [FromQuery] string first_name = null,
            [FromQuery] string last_name = null,
            [FromQuery] string email = null,
            [FromQuery] string address = null,
            [FromQuery] DateTime? birthday = null,
            [FromQuery] string memberType = null,
            [FromQuery] List<string> interests = null
            )
        {
            try
            {
                // Haal de gebruiker op uit de database
                Member member = memberService.GetMember(id);
                if (member == null)
                {
                    return NotFound("Gebruiker niet gevonden");
                }

                // Pas alleen de velden aan die zijn meegegeven (niet null)
                if (!string.IsNullOrEmpty(first_name))
                    member.first_name = first_name;
                if (!string.IsNullOrEmpty(last_name))
                    member.last_name = last_name;
                if (!string.IsNullOrEmpty(email))
                    member.email = email;
                if (!string.IsNullOrEmpty(address))
                    member.address = address;
                if (birthday.HasValue)
                    member.birthday = birthday.Value;
                //if (!string.IsNullOrEmpty(memberType))
                //    member.membertype = memberType;
                if (interests != null)
                    member.interests = interests;

                // Update het record in de database
                memberService.UpdateMember(member);

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Er is een fout opgetreden: {ex.Message}");
            }
        }

        [HttpGet("/AlleGemaakteReservatiesOphalenViaMemberID/{memberId}")]
        public ActionResult<List<Reservation>> GetReservations(int memberId)
        {
            try
            {
                List<ReservationDTO> DTOs = new List<ReservationDTO>();
                List<Reservation> reservations = reservationService.getReservationsByMemberID(memberId);
                if (reservations == null)
                {
                    return NotFound("Gebruiker niet gevonden");
                }

                foreach (Reservation RS in reservations)
                {
                    ReservationDTO DTO = new ReservationDTO
                    {
                        ReservationId = (int)RS.ReservationId,
                        TimeSlotEquipment = RS.TimeSlotEquipment,
                        Member = RS.Member,
                        Date = RS.Date
                    };

                    DTOs.Add(DTO);
                }
                return Ok(DTOs);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/AlleProgrammasWaarvoorIngeschrevenOphalenViaMemberID/{memberId}")]
        public ActionResult<List<ProgramMember>> GetProgramMembers(int memberId)
        {
            try
            {
                List<ProgramMember> programMembers = programMembersService.GetProgramMembersByMemberId(memberId);
                if (programMembers == null)
                {
                    return NotFound("Gebruiker niet gevonden");
                }

                foreach (ProgramMember programMember in programMembers)
                {
                    ProgramMemberDTO DTO = new ProgramMemberDTO
                    {
                        programCode = programMember.programCode,
                        member = programMember.member,
                    };
                }
                return Ok(programMembers);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/CyclingSessionVanGebruikerOpzoekenViaId/{id}")]
        public ActionResult<List<Cyclingsession>> GetCyclingSession(int id)
        {
            try
            {
                List<Cyclingsession> cyclingSessions = cyclingSessionService.GetCyclingSessions(id);
                if (cyclingSessions == null)
                {
                    return NotFound("Gebruiker niet gevonden");
                }

                foreach (Cyclingsession cs in cyclingSessions)
                {
                    CyclingSessionDTO DTO = new CyclingSessionDTO
                    {
                        cyclingsession_id = cs.cyclingsession_id,
                        date = cs.date,
                        duration = cs.duration,
                        avg_watt = cs.avg_watt,
                        max_watt = cs.max_watt,
                        avg_cadence = cs.avg_cadence,
                        max_cadence = cs.max_cadence,
                        trainingtype = cs.trainingtype,
                        comment = cs.comment,
                        member = cs.member
                    };
                }

                return Ok(cyclingSessions);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }

        [HttpGet("/RunningSessionVanGebruikerOpzoekenViaId/{id}")]
        public ActionResult<List<Runningsession_main>> GetRunningSession(int id)
        {
            try
            {
                List<Runningsession_main> runningSessions = runningSession_MainService.GetRunningSession_mainByMemberId(id);
                List<RunningSession_mainDTO> DTOs = new List<RunningSession_mainDTO>();
                if (runningSessions == null)
                {
                    return NotFound("Gebruiker niet gevonden");
                }

                foreach (Runningsession_main rs in runningSessions)
                {
                    RunningSession_mainDTO DTO = new RunningSession_mainDTO
                    {
                        runningSession_id = rs.runningSession_id,
                        date = rs.date,
                        duration = rs.duration,
                        avg_speed = rs.avg_speed,
                        member_id = rs.member_id
                    };
                    DTOs.Add(DTO);
                }

                return Ok(DTOs);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }

    }
}
