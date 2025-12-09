using AmadeusApi.Data;
using AmadeusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AmadeusDbContext _context;

        public DestinationRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetDestinationById(int id)
        {
            return await _context.Destinations.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Destination?> GetDestinationByCombination(string combination)
        {
            return await _context.Destinations.FirstOrDefaultAsync(d => d.Combination == combination);
        }

        public async Task<Destination> AddDestination(Destination d)
        {
            _context.Destinations.Add(d);
            await _context.SaveChangesAsync();
            return d;
        }

        public async Task<Destination> UpdateDestination(Destination d)
        {
            _context.Destinations.Update(d);
            await _context.SaveChangesAsync();
            return d;
        }

        public async Task<bool> DeleteDestination(int id)
        {
            var d = await _context.Destinations.FindAsync(id);
            if (d == null) return false;
            _context.Destinations.Remove(d);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> GetAllCombinations()
        {
            return await _context.Destinations
                .Select(d => d.Combination)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> GetDestinationCount()
        {
            return await _context.Destinations.CountAsync();
        }

        public async Task<List<Destination>> GetAllDestinationsWithCities()
        {
            return await _context.Destinations
                .Include(d => d.FirstCity)
                .Include(d => d.SecondCity)
                .ToListAsync();
        }
    }
}