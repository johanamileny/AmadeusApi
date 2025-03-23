using AMADEUSAPI.Models;
using AMADEUSAPI.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace AMADEUSAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        

        public async Task<IEnumerable<Destination>> GetAllDestinations()
        {
            return await _repository.GetAllDestinations();
        }

        public async Task<Destination> GetDestinationById(int id)
        {
            return await _repository.GetDestinationById(id);
        }



        public async Task CreateDestination(List<int> questionOptionIds, int firstCityId, int secondCityId)
        {
            string hash = GenerateHash(questionOptionIds);
         var destination = new Destination
            {
                Combination = hash,
                FirstCityId = firstCityId,
                SecondCityId = secondCityId
            };
            await _repository.AddDestination(destination);
        }

        private string GenerateHash(List<int> values)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(string.Join(",", values));
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }



        public async Task UpdateDestination(Destination destination)
        {
            await _repository.UpdateDestination(destination);
        }



        public async Task DeleteDestination(int id)
        {
            await _repository.DeleteDestination(id);
        }
    }
}