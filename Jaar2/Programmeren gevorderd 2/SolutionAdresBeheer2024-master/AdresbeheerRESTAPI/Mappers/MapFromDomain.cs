using AdresbeheerDomain.Model;
using AdresbeheerDomain.Services;
using AdresbeheerRESTAPI.Exceptions;
using AdresbeheerRESTAPI.Model.Output;

namespace AdresbeheerRESTAPI.Mappers
{
    public class MapFromDomain
    {
        public static GemeenteRESToutputDTO MapFromGemeenteDomein(string url, Gemeente gemeente, StraatService straatService)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                //lijst straten
                List<string> straten = straatService.GeefStratenGemeente(gemeente.NIScode)
                    .Select(x => gemeenteURL + $"/straat/{x.Id}").ToList();
                GemeenteRESToutputDTO dto = new GemeenteRESToutputDTO(gemeenteURL, gemeente.NIScode, gemeente.Gemeentenaam, straten.Count, straten);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
    }
}
