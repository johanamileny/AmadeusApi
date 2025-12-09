using AmadeusApi.Data;
using AmadeusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class CityRepository
    {
        private readonly AmadeusDbContext _context;

        public CityRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        // CityService.GetAllCitiesAsync
        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                .OrderBy(c => c.Country)
                .ThenBy(c => c.Language)
                .ToListAsync();
        }

        // CityService.GetByNameAsync -> usamos Description como “nombre”
        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                .FirstOrDefaultAsync(c => c.Description == name);
        }

        // CityService.GetByIdAsync
        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        }

        // CityService.CreateAsync
        public async Task<City> CreateAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        // Utilidades opcionales
        public async Task<List<City>> GetByCountryAsync(string country) =>
            await _context.Cities.Where(c => c.Country == country).ToListAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return false;
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}