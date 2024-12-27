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

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
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
    }
}
