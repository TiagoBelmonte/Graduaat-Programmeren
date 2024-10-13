using AdresbeheerDomain.Model;
using AdresbeheerDomain.Services;
using AdresbeheerRESTAPI.Mappers;
using AdresbeheerRESTAPI.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerRESTAPI.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private GemeenteService gemeenteService;
        private StraatService straatService;
        private string url = "api/adresbeheer";

        public AdresbeheerController(GemeenteService gemeenteService, StraatService straatService) 
        {
            this.straatService = straatService;
            this.gemeenteService = gemeenteService;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            Gemeente gemeente = gemeenteService.GeefGemeente(gemeenteId);
            GemeenteRESToutputDTO dto=MapFromDomain.MapFromGemeenteDomein(url,gemeente,straatService);
            return Ok(dto);
        }
    }
}
