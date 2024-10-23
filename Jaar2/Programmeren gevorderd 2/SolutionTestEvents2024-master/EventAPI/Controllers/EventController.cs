using EventServiceBL.Interfaces;
using EventServiceBL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventManager EM;
        private IVisitorManager VM;

        public EventController(IEventManager eM, IVisitorManager vM)
        {
            EM = eM;
            VM = vM;
        }

        [HttpGet("{name}")]
        public ActionResult<Event> Get(string name) 
        { 
            try
            {
                return Ok(EM.GetEvent(name));
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAll([FromQuery] string? dateString, [FromQuery] string? location) 
        {
            try
            {
                if ((!string.IsNullOrWhiteSpace(dateString)) && !string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("To many filters");
                }
                if (!string.IsNullOrWhiteSpace(location))
                {
                    return Ok(EM.GetEventsForLocation(location));
                }
                if (!string.IsNullOrWhiteSpace(dateString))
                {
                    return Ok(EM.GetEventsForDate(DateTime.Parse(dateString))); 
                }
                return Ok(EM.GetAllEvents());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost]
        [Route("{name}/Visitor")]
        public ActionResult<Event> SubscribeVisitor(string name, [FromBody] int visitorID)
        {
            try
            {
                Visitor v = VM.GetVisitor(visitorID);
                Event ev=EM.GetEvent(name);
                EM.SubscribeVisitor(v, ev);
                return CreatedAtAction(nameof(Get), new { name = name }, ev);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
