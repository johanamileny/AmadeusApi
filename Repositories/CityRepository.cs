using AMADEUSAPI.Data;
using AMADEUSAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CityRepository 
{
    private readonly ApplicationDbContext _context;

    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City> GetCityById(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city == null)
        {
            throw new KeyNotFoundException($"City with id {id} not found.");
        }
        return city;
    }

    public async Task AddCity(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCity(City city)
    {
        var existingCity = await _context.Cities.AsNoTracking()
        .FirstOrDefaultAsync(c => c.Id == city.Id);

        if (existingCity == null)
        {
            throw new KeyNotFoundException($"City with id {city.Id} not found.");
        }

        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCity(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city == null)
        {
            throw new KeyNotFoundException($"City with id {id} not found.");
        }
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
    }
}