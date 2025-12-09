using AmadeusApi.Models;
namespace AmadeusApi.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllDestinations();
        Task<Destination> GetDestinationById(int id);
        Task CreateDestination(List<int> questionOptionIds, int firstCityId, int secondCityId);
        Task UpdateDestination(Destination destination);
        Task DeleteDestination(int id);
       
        // 🆕 NUEVOS MÉTODOS
        Task<Destination> FindDestinationByAnswers(List<int> questionOptionIds);
        Task<Destination> GetDestinationByCombination(string hash);
        Task<int> GetDestinationCount();
        Task<IEnumerable<Destination>> GetAllDestinationsWithCities();
    }
}
 
 