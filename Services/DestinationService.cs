using AmadeusApi.Repositories;
using AmadeusApi.Models;
using System.Security.Cryptography;
using System.Text;
 
namespace AmadeusApi.Services
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
 
            // Verificar si la combinación ya existe en la BD
            var existingDestination = await _repository.GetDestinationByCombination(hash);
            if (existingDestination != null)
            {
                throw new InvalidOperationException("Esta combinación ya existe.");
            }
 
            var destination = new Destination
            {
                Combination = hash,
                FirstCityId = firstCityId,
                SecondCityId = secondCityId
            };
            await _repository.AddDestination(destination);
        }
 
        public async Task UpdateDestination(Destination destination)
        {
            await _repository.UpdateDestination(destination);
        }
 
        public async Task DeleteDestination(int id)
        {
            await _repository.DeleteDestination(id);
        }
 
        // 🆕 NUEVO: Buscar destino por respuestas del cuestionario con debugging
        public async Task<Destination> FindDestinationByAnswers(List<int> questionOptionIds)
        {
            try
            {
                Console.WriteLine($"🔍 [DestinationService] Buscando destino para IDs: [{string.Join(", ", questionOptionIds)}]");
               
                // Generar el hash
                var generatedHash = GenerateHash(questionOptionIds);
                Console.WriteLine($"🔑 [DestinationService] Hash generado: {generatedHash}");
               
                // 🆕 DEBUGGING: Mostrar algunos hashes de la BD para comparar
                var sampleCombinations = await _repository.GetAllCombinations();
                Console.WriteLine("📋 [DEBUG] Primeros hashes en BD:");
                foreach (var combination in sampleCombinations.Take(5))
                {
                    Console.WriteLine($"   📌 {combination.Substring(0, 16)}...");
                }
               
                // Buscar en la base de datos usando el hash generado
                var destination = await _repository.GetDestinationByCombination(generatedHash);
               
                if (destination == null)
                {
                    Console.WriteLine($"❌ [DestinationService] No se encontró destino para hash: {generatedHash.Substring(0, 16)}...");
                   
                    // Obtener total de destinos para debugging
                    var totalDestinations = await _repository.GetDestinationCount();
                    Console.WriteLine($"📊 [DEBUG] Total destinos en BD: {totalDestinations}");
                   
                    return null;
                }
               
                Console.WriteLine($"✅ [DestinationService] Destino encontrado: {destination.FirstCity?.Description} + {destination.SecondCity?.Description}");
                return destination;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [DestinationService] Error: {ex.Message}");
                throw;
            }
        }
 
        // 🆕 NUEVO: Buscar destino por respuestas del cuestionario
        public async Task<Destination> GetDestinationByCombination(List<int> questionOptionIds)
        {
            string hash = GenerateHash(questionOptionIds);
            return await _repository.GetDestinationByCombination(hash);
        }
 
        // 🆕 NUEVO: Buscar destino por hash directo
        public async Task<Destination> GetDestinationByCombination(string hash)
        {
            return await _repository.GetDestinationByCombination(hash);
        }
 
        // 🆕 MÉTODOS DE DEBUGGING
        public async Task<int> GetDestinationCount()
        {
            return await _repository.GetDestinationCount();
        }
 
        public async Task<IEnumerable<Destination>> GetAllDestinationsWithCities()
        {
            return await _repository.GetAllDestinationsWithCities();
        }
 
        private string GenerateHash(List<int> values)
        {
            // Ordenar los valores antes de generar el hash para consistencia
            var sortedValues = values.OrderBy(x => x).ToList();
           
            Console.WriteLine($"🔧 [Hash] IDs ordenados: [{string.Join(", ", sortedValues)}]");
            var hashInput = string.Join(",", sortedValues);
            Console.WriteLine($"🔧 [Hash] Input: '{hashInput}'");
           
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(hashInput);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine($"🔧 [Hash] Resultado: {hash.Substring(0, 16)}...");
                return hash;
            }
        }
    }
}