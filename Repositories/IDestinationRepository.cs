using AmadeusApi.Models;

namespace AmadeusApi.Repositories
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllDestinations();
        Task<Destination?> GetDestinationById(int id);
        Task<Destination?> GetDestinationByCombination(string combination);
        Task<Destination> AddDestination(Destination d);
        Task<Destination> UpdateDestination(Destination d);
        Task<bool> DeleteDestination(int id);
        Task<List<string>> GetAllCombinations();
        Task<int> GetDestinationCount();
        Task<List<Destination>> GetAllDestinationsWithCities();
    }
}