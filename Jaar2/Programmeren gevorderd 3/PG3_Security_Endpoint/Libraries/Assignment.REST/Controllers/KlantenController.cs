//using Assignment.Domain.Interfaces.IRepositories;
using Assignment.Repository.Repositories;
using Assignment.REST.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Assignment.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif

    public class KlantenController : ControllerBase
    {
        private readonly KlantenRepository _klantenRepository;

        public KlantenController(KlantenRepository menuRepository)
        {
            _klantenRepository = menuRepository;
        }

        // GET: api/<KlantenController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KlantenParameters parameters)
        {
            var klanten = _klantenRepository.GetAll(parameters);

            var metaData = new
            {
                klanten.TotalCount,
                klanten.PageSize,
                klanten.CurrentPage,
                klanten.TotalPages,
                klanten.HasNext,
                klanten.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(klanten);
        }

        // GET api/<KlantenController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var klant = _klantenRepository.GetByID(id);
            return Ok(klant);
        }

        // POST api/<KlantenController>
        [HttpPost]
        public void Post([FromBody] KlantDTO value)
        {
        }

        // PUT api/<KlantenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KlantenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}