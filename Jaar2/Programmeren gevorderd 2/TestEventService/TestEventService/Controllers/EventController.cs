using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TestEventService.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestEventService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        //[HttpGet]
        //public IEnumerable<Event> Get()
        //{
        //    return _eventRepository.GetAll();
        //}


        [HttpGet]
        public IEnumerable<Event> Getall([FromQuery] string? name, [FromQuery] DateTime? date, [FromQuery]string? location)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _eventRepository.GetEventName(name);
            }
            else
            if (date != null)
            {
                return _eventRepository.GetEventDate(Convert.ToDateTime(date));
            }
            else
            if (!string.IsNullOrWhiteSpace(location))
            {
                return _eventRepository.GetEventLocation(location);
            }
            else
            {
                return _eventRepository.GetAll();

            }
            
        }


            [HttpPut("{name}")]
        public IActionResult Put([FromBody] Event Event)
        {
            if (Event == null)
            {
                return BadRequest();
            }
            else
            {
                _eventRepository.AddEvent(Event);
                return CreatedAtAction(nameof(Event), new { id = Event.Id }, Event);
            }

            
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            _eventRepository.RemoveEvent(name);
            return NoContent();
        }

        [HttpPost("{nameEvent}, {visitorID}")]
        public ActionResult<Event> Post([FromBody] string nameEvent, int visitorID)
        {
            _eventRepository.addVisitor(nameEvent, visitorID);
            return NoContent();
        }
    }
}

