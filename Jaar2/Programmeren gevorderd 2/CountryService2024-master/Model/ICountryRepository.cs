namespace CountryService2024.Model
{
    public interface ICountryRepository
    {
        void AddCountry(Country country);
        Country GetCountry(int id);
        IEnumerable<Country> GetAll();
        IEnumerable<Country> GetAll(string continent);
        IEnumerable<Country> GetAll(string continent, string capital);
        void RemoveCountry(Country country);
        void UpdateCountry(Country country);
    }
}
