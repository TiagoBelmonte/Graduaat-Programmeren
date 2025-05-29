using FitnessAPI.DTO;
using FitnessBL.Enums;
using FitnessBL.Exceptions;
using FitnessBL.Model;
using FitnessBL.Services;
using FitnessEF.Model;
using Microsoft.AspNetCore.Mvc;
using ProgramBL = FitnessBL.Model.Program;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberService memberService;

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet("/LijstMembers")]
        public IActionResult GetMembers()
        {
            try
            {
                IEnumerable<Member> members = memberService.GetMembers();
                return Ok(members);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/MemberViaNaam/{voornaam}/{achternaam}")]
        public IActionResult GetMemberNaam(string voornaam, string achternaam)
        {
            try
            {
                IEnumerable<Member> members = memberService.GetMemberNaam(voornaam, achternaam);
                return Ok(members);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

        [HttpGet("/TrainingSessionsMember/{id}")]
        public IActionResult GetTrainingSessionsMember(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                IEnumerable<TrainingSession> trainingSessions =
                    memberService.GetTrainingSessionsMember(member);

                // Maak een lijst om DTO-objecten op te slaan
                List<TrainingSessionDTO> trainingSessionDTOs = new List<TrainingSessionDTO>();

                // Itereer door alle trainingssessies
                foreach (TrainingSession ts in trainingSessions)
                {
                    TrainingSessionDTO sessionDTO = new TrainingSessionDTO
                    {
                        Date = ts.Date,
                        Duration = ts.Duration
                    };

                    if (ts is Runningsession_main runningSession)
                    {
                        sessionDTO.Id = runningSession.Runningsession_id;
                        sessionDTO.SessionType = "Running";
                        sessionDTO.AvgSpeed = runningSession.Avg_speed;
                    }
                    else if (ts is Cyclingsession cyclingSession)
                    {
                        sessionDTO.Id = cyclingSession.Cyclingsession_id;
                        sessionDTO.SessionType = "Cycling";
                        sessionDTO.AvgWatt = cyclingSession.Avg_watt;
                        sessionDTO.MaxWatt = cyclingSession.Max_watt;
                        sessionDTO.AvgCadence = cyclingSession.Avg_cadence;
                        sessionDTO.MaxCadence = cyclingSession.Max_cadence;
                        sessionDTO.TrainingsType = cyclingSession.TrainingsType;
                        sessionDTO.Comment = cyclingSession.Comment;
                    }

                    // Voeg de DTO toe aan de lijst
                    trainingSessionDTOs.Add(sessionDTO);
                }

                return Ok(trainingSessionDTOs);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/AlleProgramsPerMemberID/{id}")]
        public IActionResult GetProgramListMember(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                IEnumerable<ProgramBL> programs = memberService.GetProgramListMember(member);

                List<ProgramDTO> programDTOs = new List<ProgramDTO>();
                foreach (ProgramBL program in programs)
                {
                    ProgramDTO pDTO = new ProgramDTO
                    {
                        ProgramCode = program.ProgramCode,
                        Name = program.Name,
                        Target = program.Target,
                        StartDate = program.Startdate.Date,
                        MaxMembers = program.Max_members
                    };

                    programDTOs.Add(pDTO);
                }

                return Ok(programDTOs);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/ReservationsMember/{id}")]
        public IActionResult GetReservationsMember(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                IEnumerable<Reservation> reservations = memberService.GetReservationsMember(member);

                List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
                List<TimeslotEquipmentDTO> tseDTOs = new List<TimeslotEquipmentDTO>();
                foreach (Reservation r in reservations)
                {
                    foreach (KeyValuePair<Time_slot, Equipment> kvp in r.TimeslotEquipment)
                    {
                        TimeslotEquipmentDTO tseDTO = new TimeslotEquipmentDTO
                        {
                            Time_slot_id = kvp.Key.Time_slot_id,
                            Equipment_id = kvp.Value.Equipment_id,
                        };

                        tseDTOs.Add(tseDTO);
                    }

                    ReservationDTO rDTO = new ReservationDTO
                    {
                        ReservationId = r.Reservation_id,
                        MemberId = r.Member.Member_id,
                        Date = r.Date,
                        EquipmentPerTimeslot = tseDTOs
                    };

                    reservationDTOs.Add(rDTO);
                    tseDTOs = new List<TimeslotEquipmentDTO>();
                }

                return Ok(reservationDTOs);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/TrainingSessionsMemberVanMaandInJaar/{id}/{maand}/{jaar}")]
        public IActionResult TrainingSessionsMemberPerMaandInJaar(int id, int maand, int jaar)
        {
            try
            {
                DateTime date = new DateTime(jaar, maand, 1);
                Member member = memberService.GetMemberId(id);
                IEnumerable<TrainingSession> TrainingSessions =
                    memberService.GetTrainingSessionsMemberInMaandInJaar(member, date);

                // Maak een lijst om DTO-objecten op te slaan
                List<TrainingSessionDTO> trainingSessionDTOs = new List<TrainingSessionDTO>();

                // Itereer door alle trainingssessies
                foreach (TrainingSession ts in TrainingSessions)
                {
                    TrainingSessionDTO sessionDTO = new TrainingSessionDTO
                    {
                        Date = ts.Date,
                        Duration = ts.Duration
                    };

                    if (ts is Runningsession_main runningSession)
                    {
                        sessionDTO.Id = runningSession.Runningsession_id;
                        sessionDTO.SessionType = "Running";
                        sessionDTO.AvgSpeed = runningSession.Avg_speed;
                    }
                    else if (ts is Cyclingsession cyclingSession)
                    {
                        sessionDTO.Id = cyclingSession.Cyclingsession_id;
                        sessionDTO.SessionType = "Cycling";
                        sessionDTO.AvgWatt = cyclingSession.Avg_watt;
                        sessionDTO.MaxWatt = cyclingSession.Max_watt;
                        sessionDTO.AvgCadence = cyclingSession.Avg_cadence;
                        sessionDTO.MaxCadence = cyclingSession.Max_cadence;
                        sessionDTO.TrainingsType = cyclingSession.TrainingsType;
                        sessionDTO.Comment = cyclingSession.Comment;
                    }

                    // Voeg de DTO toe aan de lijst
                    trainingSessionDTOs.Add(sessionDTO);
                }

                return Ok(trainingSessionDTOs);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/TrainingSessionsMember(GesorteerdOpTijd)/{id}")]
        public IActionResult GetTrainingSessionsMemberGegevensTijd(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                IEnumerable<TrainingSession> TrainingSessions =
                    memberService.GetTrainingSessionsMember(member);

                TrainingSession langsteTs = TrainingSessions.First();
                TrainingSession kortsteTs = TrainingSessions.First();
                decimal aantalMinuten = 0;

                foreach (TrainingSession trainingSession in TrainingSessions)
                {
                    aantalMinuten += trainingSession.Duration;
                    if (langsteTs.Duration > trainingSession.Duration)
                        langsteTs = trainingSession;
                    if (kortsteTs.Duration < trainingSession.Duration)
                        kortsteTs = trainingSession;
                }

                TrainingSessionDTO langsteTsDTO = null;
                TrainingSessionDTO kortsteTsDTO = null;

                if (langsteTs is Runningsession_main runningSession)
                {
                    // Voeg een DTO-object toe met alleen relevante velden voor een RunningSession
                    langsteTsDTO = new TrainingSessionDTO
                    {
                        SessionType = "Running",
                        Id = runningSession.Runningsession_id,
                        Date = runningSession.Date,
                        Duration = runningSession.Duration,
                        AvgSpeed = runningSession.Avg_speed
                    };
                }
                else if (langsteTs is Cyclingsession cyclingSession)
                {
                    // Voeg een DTO-object toe met alleen relevante velden voor een CyclingSession
                    langsteTsDTO = new TrainingSessionDTO
                    {
                        SessionType = "Cycling",
                        Id = cyclingSession.Cyclingsession_id,
                        Date = cyclingSession.Date,
                        Duration = cyclingSession.Duration,
                        AvgWatt = cyclingSession.Avg_watt,
                        MaxWatt = cyclingSession.Max_watt,
                        AvgCadence = cyclingSession.Avg_cadence,
                        MaxCadence = cyclingSession.Max_cadence,
                        TrainingsType = cyclingSession.TrainingsType,
                        Comment = cyclingSession.Comment
                    };
                }

                if (kortsteTs is Runningsession_main runningSession2)
                {
                    // Voeg een DTO-object toe met alleen relevante velden voor een RunningSession
                    kortsteTsDTO = new TrainingSessionDTO
                    {
                        SessionType = "Running",
                        Id = runningSession2.Runningsession_id,
                        Date = runningSession2.Date,
                        Duration = runningSession2.Duration,
                        AvgSpeed = runningSession2.Avg_speed
                    };
                }
                else if (kortsteTs is Cyclingsession cyclingSession)
                {
                    // Voeg een DTO-object toe met alleen relevante velden voor een CyclingSession
                    kortsteTsDTO = new TrainingSessionDTO
                    {
                        SessionType = "Cycling",
                        Id = cyclingSession.Cyclingsession_id,
                        Date = cyclingSession.Date,
                        Duration = cyclingSession.Duration,
                        AvgWatt = cyclingSession.Avg_watt,
                        MaxWatt = cyclingSession.Max_watt,
                        AvgCadence = cyclingSession.Avg_cadence,
                        MaxCadence = cyclingSession.Max_cadence,
                        TrainingsType = cyclingSession.TrainingsType,
                        Comment = cyclingSession.Comment
                    };
                }

                decimal aantalUren = aantalMinuten / 60;

                TrainingSessionMetLangsteEnKortsteDTO tsDTO =
                    new TrainingSessionMetLangsteEnKortsteDTO
                    {
                        AantalTrainingSessions = TrainingSessions.Count(),
                        AantalUren = Math.Round(aantalUren, 2),
                        LangsteTrainingSession = langsteTsDTO,
                        KortsteTrainingSession = kortsteTsDTO,
                        GemiddeldeDuur = Math.Round(aantalMinuten / TrainingSessions.Count()),
                    };

                return Ok(tsDTO);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/TrainingSessionsMemberInMaandInJaar/{id}/{maand}/{jaar}")]
        public IActionResult GetTrainingSessionsMemberInMaandInJaar(int id, int maand, int jaar)
        {
            try
            {
                DateTime date = new DateTime(jaar, maand, 1);
                Member member = memberService.GetMemberId(id);
                IEnumerable<TrainingSession> TrainingSessions =
                    memberService.GetTrainingSessionsMemberInMaandInJaar(member, date);

                // Maak een lijst om DTO-objecten op te slaan
                List<TrainingSessionDTO> trainingSessionDTOs = new List<TrainingSessionDTO>();

                // Itereer door alle trainingssessies
                foreach (TrainingSession ts in TrainingSessions)
                {
                    TrainingSessionDTO sessionDTO = new TrainingSessionDTO
                    {
                        Date = ts.Date,
                        Duration = ts.Duration
                    };

                    if (ts is Runningsession_main runningSession)
                    {
                        sessionDTO.Id = runningSession.Runningsession_id;
                        sessionDTO.SessionType = "Running";
                        sessionDTO.AvgSpeed = runningSession.Avg_speed;
                    }
                    else if (ts is Cyclingsession cyclingSession)
                    {
                        string trainingsImpact = "High";

                        if (cyclingSession.Avg_watt < 150 && cyclingSession.Duration <= 90)
                            trainingsImpact = "Low";
                        if (
                            cyclingSession.Avg_watt < 150 && cyclingSession.Duration > 90
                            || cyclingSession.Avg_watt >= 150 && cyclingSession.Avg_watt <= 200
                        )
                            trainingsImpact = "Medium";

                        sessionDTO.Id = cyclingSession.Cyclingsession_id;
                        sessionDTO.SessionType = "Cycling";
                        sessionDTO.AvgWatt = cyclingSession.Avg_watt;
                        sessionDTO.MaxWatt = cyclingSession.Max_watt;
                        sessionDTO.AvgCadence = cyclingSession.Avg_cadence;
                        sessionDTO.MaxCadence = cyclingSession.Max_cadence;
                        sessionDTO.TrainingsType = cyclingSession.TrainingsType;
                        sessionDTO.Comment = cyclingSession.Comment;
                        sessionDTO.TrainingsImpact = trainingsImpact;
                    }

                    // Voeg de DTO toe aan de lijst
                    trainingSessionDTOs.Add(sessionDTO);
                }

                return Ok(trainingSessionDTOs);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/TrainingSessionsMemberAantalPerMaandInJaar/{id}/{jaar}")]
        public IActionResult GetTrainingSessionsMemberAantalPerMaandInJaar(int id, int jaar)
        {
            try
            {
                DateTime date = new DateTime(jaar, 1, 1);
                Member member = memberService.GetMemberId(id);
                Dictionary<int, int> sessiesPerMaand =
                    memberService.GetTrainingSessionsMemberAantalPerMaandInJaar(member, date);
                Dictionary<string, string> result = new Dictionary<string, string>();

                foreach (KeyValuePair<int, int> kvp in sessiesPerMaand)
                {
                    result.Add($"Maand {kvp.Key}", $"Aantal Sessies: {kvp.Value}");
                }

                TrainingSessionMemberSessiesAantalPerMaandDTO aantalPerMaandDTO =
                    new TrainingSessionMemberSessiesAantalPerMaandDTO { SessiesPerMaand = result };

                return Ok(aantalPerMaandDTO);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/TrainingSessionsMemberAantalPerMaandInJaarMetType/{id}/{jaar}")]
        public IActionResult GetTrainingSessionsMemberAantalPerMaandInJaarMetType(int id, int jaar)
        {
            try
            {
                DateTime date = new DateTime(jaar, 1, 1);
                Member member = memberService.GetMemberId(id);
                Dictionary<string, Dictionary<int, int>> sessiesPerMaand =
                    memberService.GetTrainingSessionsMemberAantalPerMaandInJaarMetType(
                        member,
                        date
                    );
                Dictionary<string, string> tussenResultaat = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, string>> result =
                    new Dictionary<string, Dictionary<string, string>>();

                foreach (KeyValuePair<string, Dictionary<int, int>> kvp in sessiesPerMaand)
                {
                    foreach (KeyValuePair<int, int> keyValuePair in kvp.Value)
                    {
                        tussenResultaat.Add(
                            $"Maand {keyValuePair.Key}",
                            $"Aantal Sessies: {keyValuePair.Value}"
                        );
                    }

                    result.Add(kvp.Key, tussenResultaat);
                    tussenResultaat = new Dictionary<string, string>();
                }

                TrainingSessionMemberAantalPerMaandInJaarMetTypeDTO aantalPerMaandDTO =
                    new TrainingSessionMemberAantalPerMaandInJaarMetTypeDTO
                    {
                        SessiesPerMaand = result
                    };

                return Ok(aantalPerMaandDTO);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/MemberViaId/{id}")]
        public IActionResult GetMemberId(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                return Ok(member);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Member")]
        public IActionResult AddMember([FromBody] MemberAanmakenDTO memberDTO)
        {
            try
            {
                List<string> intr = new List<string>();
                if (memberDTO.Interests.Count >= 1 && !memberDTO.Interests.Contains("string"))
                {
                    foreach (string str in memberDTO.Interests)
                    {
                        intr.Add(str);
                    }
                }
                Member member = new Member(
                    memberDTO.FirstName,
                    memberDTO.LastName,
                    memberDTO.Email,
                    memberDTO.Address,
                    (DateTime)memberDTO.Birthday,
                    intr,
                    (TypeKlant)memberDTO.TypeMember
                );

                memberService.AddMember(member);

                return CreatedAtAction(
                    nameof(GetMemberId), // Specify the action name of the "Get" endpoint
                    new { id = member.Member_id }, // Parameter voor de Get eindpoint
                    member // Return the created gebruiker object
                );
            }
            catch (MemberException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("/Member/{id}")]
        public IActionResult UpdateMember(
     int id,
     [FromBody] MemberAanmakenDTO updateRequest
 )
        {
            try
            {
                // Haal de gebruiker op uit de database
                Member member = memberService.GetMemberId(id);

                // Update alleen de velden die niet null zijn
                if (!string.IsNullOrEmpty(updateRequest.FirstName))
                    member.FirstName = updateRequest.FirstName;
                if (!string.IsNullOrEmpty(updateRequest.LastName))
                    member.LastName = updateRequest.LastName;
                if (!string.IsNullOrEmpty(updateRequest.Email))
                    member.Email = updateRequest.Email;
                if (!string.IsNullOrEmpty(updateRequest.Address))
                    member.Address = updateRequest.Address;
                if (updateRequest.Birthday.HasValue)
                    member.Birthday = updateRequest.Birthday.Value;
                if (updateRequest.Interests != null && updateRequest.Interests.Any())
                    member.Interests = updateRequest.Interests;
                if (updateRequest.TypeMember.HasValue)
                    member.MemberType = updateRequest.TypeMember.Value;

                // Update het record in de database
                memberService.UpdateMember(member);

                return CreatedAtAction(
                    nameof(GetMemberId),
                    new { id = member.Member_id },
                    member
                );
            }
            catch (MemberException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/MemberViaId/{id}")]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                Member member = memberService.GetMemberId(id);
                memberService.DeleteMember(member);
                return Ok("De member is succesvol verwijderd!");
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
