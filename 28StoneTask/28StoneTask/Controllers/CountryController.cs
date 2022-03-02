using _28StoneTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace _28StoneTask.Controllers;

public class CountryController : Controller
{
    private readonly ICountryService _service;

    public CountryController(ICountryService service)
    {
        _service = service;
    }

    [HttpGet("/Country")]
    public async Task<IActionResult> GetAllCountries()
    {
        return Ok(await _service.GetAllEuCountries());
    }

    [HttpGet("/Country/TopTenByPopulation")]
    public async Task<IActionResult> GetTopTenByPopulation()
    {
        return Ok(await _service.GetEuCountriesTopTenByPopulation());
    }

    [HttpGet("/Country/TopTenByDensity")]
    public async Task<IActionResult> GetTopTenByDensity()
    {
        return Ok(await _service.GetEuCountriesTopTenByDensity());
    }

    [HttpGet("/Country/{name}")]
    public async Task<IActionResult> GetCountryByName(string name)
    {
        return Ok(await _service.GetCountryInformationExceptName(name));
    }
}