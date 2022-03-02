using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _28StoneTask.Models;
using _28StoneTask.Services;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Xunit;

namespace _28StoneTaskTests;

public class CountryServiceTests
{
    [Fact]
    public async Task GetCountryInformationExceptName_InputCountry_ShouldReturnCountryByNameResult()
    {
        //Arrange   
        var mock = new AutoMocker();
        mock.GetMock<ICountry>().Setup(a => a.GetCountryInformationExceptName("Latvia")).ReturnsAsync(() =>
            new List<Country>
            {
                new()
                {
                    Name = "Latvia",
                    Area = 64559,
                    Population = 1901548,
                    TopLevelDomain = new List<string> {".lv"},
                    NativeName = "Latvija"
                }
            });

        var expected = new CountryByNameResult
        {
            Area = 64559,
            Population = 1901548,
            TopLevelDomain = new List<string> {".lv"},
            NativeName = "Latvija"
        };

        ICountryService target = new CountryService(mock.GetMock<ICountry>().Object);

        //Act
        var result = await target.GetCountryInformationExceptName("Latvia");
        var expectedObject = JsonConvert.SerializeObject(expected);
        var resultObject = JsonConvert.SerializeObject(result);

        //Assert
        Assert.Equal(expectedObject, resultObject);
    }

    [Fact]
    public async Task GetEuCountriesTopTenByDensity_InputCountries_ShouldReturnTopCountriesByDensity()
    {
        //Arrange   
        var mock = new AutoMocker();
        var sortable = new List<Country>
        {
            new()
            {
                Name = "Estonia",
                Area = 45227,
                Population = 1331057,
                TopLevelDomain = new List<string> {".ee"},
                NativeName = "Eesti",
                Independent = true
            },
            new()
            {
                Name = "Latvia",
                Area = 64559,
                Population = 1901548,
                TopLevelDomain = new List<string> {".lv"},
                NativeName = "Latvija",
                Independent = true
            }
        };

        mock.GetMock<ICountry>().Setup(a => a.GetEuCountries()).ReturnsAsync(() => sortable);

        var expected = sortable.OrderByDescending(c => c.Population / c.Area).ToList();

        ICountryService target = new CountryService(mock.GetMock<ICountry>().Object);

        //Act
        var result = await target.GetEuCountriesTopTenByDensity();

        //Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public async Task GetEuCountriesTopTenByPopulation_InputCountries_ShouldReturnTopCountriesByPopulation()
    {
        //Arrange   
        var mock = new AutoMocker();
        var sortable = new List<Country>
        {
            new()
            {
                Name = "Estonia",
                Area = 45227,
                Population = 1331057,
                TopLevelDomain = new List<string> {".ee"},
                NativeName = "Eesti",
                Independent = true
            },
            new()
            {
                Name = "Latvia",
                Area = 64559,
                Population = 1901548,
                TopLevelDomain = new List<string> {".lv"},
                NativeName = "Latvija",
                Independent = true
            }
        };
        mock.GetMock<ICountry>().Setup(a => a.GetEuCountries()).ReturnsAsync(() => sortable);

        var expected = sortable.OrderByDescending(c => c.Population).ToList();

        ICountryService target = new CountryService(mock.GetMock<ICountry>().Object);

        //Act
        var result = await target.GetEuCountriesTopTenByPopulation();

        //Assert
        result.Should().Equal(expected);
    }
}