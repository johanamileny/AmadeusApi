using AmadeusApi.Models;
using AmadeusApi.Repositories;

namespace AmadeusApi.Services
{
    public class CityService
    {
        private readonly CityRepository _cityRepository;

        public CityService(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync();
        }

        public async Task<City?> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<City?> GetCityByNameAsync(string name)
        {
            return await _cityRepository.GetByNameAsync(name);
        }

        public async Task<City> CreateCityAsync(City city)
        {
            return await _cityRepository.CreateAsync(city);
        }
    }
}
