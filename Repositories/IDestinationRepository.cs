using AMADEUSAPI.Models;

namespace AMADEUSAPI.Repositories
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllDestinations();
        Task<Destination> GetDestinationById(int id);
        Task AddDestination(Destination destination);
        Task UpdateDestination(Destination destination);
        Task DeleteDestination(int id);
        Task<Destination?> GetDestinationByCombination(string combination);
        
    }
}