using _28StoneTask.Models;
using Refit;

namespace _28StoneTask.Services;

public interface ICountry
{
    [Get("/v2/regionalbloc/eu")]
    Task<List<Country>> GetEuCountries();

    [Get("/v2/name/{name}")]
    Task<List<Country>> GetCountryInformationExceptName(string name);
}