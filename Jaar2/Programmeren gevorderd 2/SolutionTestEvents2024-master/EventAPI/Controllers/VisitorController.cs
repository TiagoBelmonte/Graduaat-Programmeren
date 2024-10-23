using EventServiceBL.Interfaces;
using EventServiceBL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IVisitorManager VM;
        public VisitorController(IVisitorManager vm)
        {
            VM = vm;
        }
        [HttpGet("{id}")]
        public ActionResult<Visitor> Get(int id)
        {
            try
            {
                return Ok(VM.GetVisitor(id));
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public ActionResult<List<Visitor>> GetAll() 
        {
            try
            {
                return Ok(VM.GetAllVisitor());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<Visitor> Post([FromBody] Visitor visitor)
        {
            if (visitor == null) { return BadRequest("invalid visitor"); }
            try
            {
                visitor = VM.RegisterVisitor(visitor);
                VM.SubscribeVisitor(visitor);
                return CreatedAtAction(nameof(Get),new {id=visitor.Id},visitor);
            }
            catch(Exception ex) { return BadRequest(ex.Message);}
        }
    }
}
