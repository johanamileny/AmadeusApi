using AMADEUSAPI.Models;

namespace AMADEUSAPI.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllDestinations();
        Task<Destination> GetDestinationById(int id);
        Task CreateDestination(List<int> questionOptionIds, int firstCityId, int secondCityId);
        Task UpdateDestination(Destination destination);
        Task DeleteDestination(int id);
    }
}