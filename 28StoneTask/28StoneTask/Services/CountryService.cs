using _28StoneTask.Models;

namespace _28StoneTask.Services;

public class CountryService : ICountryService
{
    private readonly ICountry _countryService;

    public CountryService(ICountry countryService)
    {
        _countryService = countryService;
    }

    public async Task<List<Country>> GetAllEuCountries()
    {
        var countries = await _countryService.GetEuCountries();
        var isIndependent = countries.Where(c => c.Independent).ToList();

        return isIndependent;
    }

    public async Task<List<Country>> GetEuCountriesTopTenByPopulation()
    {
        var countries = await _countryService.GetEuCountries();
        var isIndependent = countries.Where(c => c.Independent);
        var countriesByPopulation = isIndependent
            .OrderByDescending(c => c.Population).Take(10).ToList();

        return countriesByPopulation;
    }

    public async Task<List<Country>> GetEuCountriesTopTenByDensity()
    {
        var countries = await _countryService.GetEuCountries();
        var isIndependent = countries.Where(c => c.Independent);
        var countriesByDensity = isIndependent
            .OrderByDescending(c => c.Population / c.Area).Take(10).ToList();

        return countriesByDensity;
    }

    public async Task<CountryByNameResult> GetCountryInformationExceptName(string name)
    {
        var countriesByName = await _countryService.GetCountryInformationExceptName(name);
        var modelProperties = countriesByName
            .Select(c => new CountryByNameResult
            {
                Area = c.Area,
                Population = c.Population,
                TopLevelDomain = c.TopLevelDomain,
                NativeName = c.NativeName
            });

        return modelProperties.FirstOrDefault();
    }
}