using AMADEUSAPI.Data;
using AMADEUSAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CityService
{
    private readonly CityRepository _cityRepository;

    public CityService(CityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _cityRepository.GetAllCities();
    }

    public async Task<City> GetCityById(int id)
    {
        return await _cityRepository.GetCityById(id);
    }

    public async Task CreateCity(string description)
    {
        var city = new City { Description = description };
        await _cityRepository.AddCity(city);
    }

    public async Task UpdateCity(City city)
    {
        await _cityRepository.UpdateCity(city);
    }

    public async Task DeleteCity(int id)
    {
        await _cityRepository.DeleteCity(id);
    }
}
