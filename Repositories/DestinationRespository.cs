using AMADEUSAPI.Data;
using AMADEUSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AMADEUSAPI.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllDestinations()
        {
            return await _context.Destinations.ToListAsync();
        }



        public async Task<Destination> GetDestinationById(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination == null)
            {
                throw new KeyNotFoundException($"Destination with id {id} not found.");
            }
            return destination;
        }




        public async Task AddDestination(Destination destination)
        {
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateDestination(Destination destination)
{
        var existingDestination = await _context.Destinations.AsNoTracking()
        .FirstOrDefaultAsync(d => d.Id == destination.Id);

          if (existingDestination == null)
        {
        throw new KeyNotFoundException($"No se encontró Destination con ID {destination.Id}");
     }

          _context.Destinations.Update(destination);
           await _context.SaveChangesAsync();
        }



        public async Task DeleteDestination(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
        if (destination == null)
        {
            throw new KeyNotFoundException($"Destination with id {id} not found.");
        }
        _context.Destinations.Remove(destination);
        await _context.SaveChangesAsync();
        }
    }
}
    
