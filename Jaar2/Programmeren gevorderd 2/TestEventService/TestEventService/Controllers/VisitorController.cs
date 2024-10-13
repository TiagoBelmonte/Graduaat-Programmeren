using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TestEventService.Model;

namespace TestEventService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IVisitorsRepository _visitorsRepository;

        public VisitorController(IVisitorsRepository visitorsRepository) 
        {
            _visitorsRepository = visitorsRepository;
        }

        [HttpGet]
        public IEnumerable<Visitor> Get()
        {
            return _visitorsRepository.GetAll();
        }

        [HttpPost]
        public ActionResult<Visitor> Post([FromBody] Visitor visitor)
        {
            _visitorsRepository.AddVistor(visitor);
            return CreatedAtAction(nameof(Get), new { id = visitor.Id }, visitor);
        }

        [HttpGet("{id}")]
        public ActionResult<Visitor> Get(int id)
        {
            try
            {
                return _visitorsRepository.GetVisitor(id);
            }
            catch (VisitorExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
    }


}
