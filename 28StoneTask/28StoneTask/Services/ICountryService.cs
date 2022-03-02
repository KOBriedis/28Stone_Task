using _28StoneTask.Models;

namespace _28StoneTask.Services;

public interface ICountryService
{
    Task<List<Country>> GetAllEuCountries();

    Task<List<Country>> GetEuCountriesTopTenByPopulation();

    Task<List<Country>> GetEuCountriesTopTenByDensity();

    Task<CountryByNameResult> GetCountryInformationExceptName(string name);
}