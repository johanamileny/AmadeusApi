using AmadeusApi.Models;
using AmadeusApi.Services;
using Microsoft.AspNetCore.Mvc;
using AmadeusApi.Contracts;
using System.Security.Cryptography;
using System.Text;
 
namespace AmadeusApi.Controllers
{
    [Route("api/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _service;
 
        public DestinationController(IDestinationService service)
        {
            _service = service;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllDestinations());
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetDestinationById(id));
        }
 
        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] CreateDestinationRequest request)
        {
            await _service.CreateDestination(request.QuestionOptionIds, request.FirstCityId, request.SecondCityId);
            return Ok(new { message = "Destination created successfully" });
        }
 
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDestination(int id, [FromBody] Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la solicitud.");
            }
 
            try
            {
                await _service.UpdateDestination(destination);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
 
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                await _service.DeleteDestination(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
 
        [HttpPost("find-by-answers")]
        public async Task<IActionResult> FindByAnswers([FromBody] List<int> questionOptionIds)
        {
            try
            {
                Console.WriteLine($"🔍 [Controller] Recibiendo IDs: [{string.Join(", ", questionOptionIds)}]");
 
                // ✅ CORRECCIÓN: Usar _service en lugar de _destinationService
                var destination = await _service.FindDestinationByAnswers(questionOptionIds);
 
                if (destination == null)
                {
                    Console.WriteLine("❌ [Controller] No se encontró destino");
                    return NotFound("No se encontró destino para esta combinación de respuestas");
                }
 
                Console.WriteLine($"✅ [Controller] Destino encontrado: {destination.Id}");
                return Ok(destination);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [Controller] Error: {ex.Message}");
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
 
        [HttpPost("debug/test-hash")]
        public async Task<IActionResult> TestHash([FromBody] List<int> questionOptionIds)
        {
            try
            {
                Console.WriteLine($"🧪 [TEST] Testing combination: [{string.Join(", ", questionOptionIds)}]");
               
                // Generar hash con la lógica actual
                var sortedIds = questionOptionIds.OrderBy(x => x).ToList();
                var hashInput = string.Join(",", sortedIds);
               
                string generatedHash;
                using (var sha256 = SHA256.Create())
                {
                    var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
                    generatedHash = Convert.ToHexString(hashBytes).ToLower();
                }
               
                Console.WriteLine($"🔑 [TEST] Generated hash: {generatedHash}");
               
                // Obtener TODOS los hashes de la BD para comparar
                var allDestinations = await _service.GetAllDestinationsWithCities();
                var allHashes = allDestinations.Select(d => new
                {
                    Id = d.Id,
                    Hash = d.Combination,
                    FirstCity = d.FirstCity?.Description,
                    SecondCity = d.SecondCity?.Description
                }).ToList();
               
                // Buscar coincidencia exacta
                var exactMatch = allHashes.FirstOrDefault(h => h.Hash == generatedHash);
               
                // Buscar coincidencias parciales (primeros 8 caracteres)
                var partialMatches = allHashes
                    .Where(h => h.Hash.StartsWith(generatedHash.Substring(0, 8)))
                    .ToList();
               
                // ✅ CORRECCIÓN: Crear objeto ExactMatch por separado
                object exactMatchResult;
                if (exactMatch != null)
                {
                    exactMatchResult = new
                    {
                        Found = true,
                        Id = exactMatch.Id,
                        FirstCity = exactMatch.FirstCity,
                        SecondCity = exactMatch.SecondCity
                    };
                }
                else
                {
                    exactMatchResult = new
                    {
                        Found = false,
                        Id = (int?)null,
                        FirstCity = (string?)null,
                        SecondCity = (string?)null
                    };
                }
               
                return Ok(new
                {
                    Input = new
                    {
                        OriginalIds = questionOptionIds,
                        SortedIds = sortedIds,
                        HashInput = hashInput,
                        GeneratedHash = generatedHash.Length > 16 ? generatedHash.Substring(0, 16) + "..." : generatedHash,
                        FullGeneratedHash = generatedHash
                    },
                    Result = new
                    {
                        ExactMatch = exactMatchResult,
                        PartialMatches = partialMatches.Count,
                        TotalHashesInDB = allHashes.Count
                    },
                    FirstFiveHashesInDB = allHashes.Take(5).Select(h => new
                    {
                        Id = h.Id,
                        HashPreview = h.Hash.Length > 16 ? h.Hash.Substring(0, 16) + "..." : h.Hash,
                        Cities = $"{h.FirstCity} + {h.SecondCity}"
                    })
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [TEST] Error: {ex.Message}");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
 
        [HttpGet("debug/all-combinations")]
        public async Task<IActionResult> GetAllCombinations()
        {
            try
            {
                // ✅ CORRECCIÓN: Usar _service en lugar de _destinationService
                var destinations = await _service.GetAllDestinationsWithCities();
 
                return Ok(new
                {
                    Total = destinations.Count(),
                    Combinations = destinations.Take(10).Select(d => new
                    {
                        Id = d.Id,
                        Hash = d.Combination.Substring(0, 16) + "...",
                        FullHash = d.Combination,
                        FirstCity = d.FirstCity?.Description,
                        SecondCity = d.SecondCity?.Description
                    })
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
 
        [HttpGet("debug/database-status")]
        public async Task<IActionResult> GetDatabaseStatus()
        {
            try
            {
                var destinationCount = await _service.GetDestinationCount();
                var sampleDestinations = await _service.GetAllDestinationsWithCities();
               
                return Ok(new
                {
                    DestinationCount = destinationCount,
                    SampleDestinations = sampleDestinations.Take(5).Select(d => new
                    {
                        Id = d.Id,
                        HashPreview = d.Combination.Length > 16 ? d.Combination.Substring(0, 16) + "..." : d.Combination,
                        FirstCity = d.FirstCity?.Description ?? "NULL",
                        SecondCity = d.SecondCity?.Description ?? "NULL"
                    })
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
 
        [HttpGet("debug/all-hashes")]
        public async Task<IActionResult> GetAllHashes()
        {
            try
            {
                var destinations = await _service.GetAllDestinationsWithCities();
               
                var result = destinations.Select(d => new
                {
                    Id = d.Id,
                    FullHash = d.Combination,
                    HashPreview = d.Combination.Substring(0, 16) + "...",
                    FirstCity = d.FirstCity?.Description,
                    SecondCity = d.SecondCity?.Description
                }).ToList();
               
                return Ok(new
                {
                    Total = result.Count,
                    AllCombinations = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
 
        [HttpPost("debug/test-python-hash")]
        public async Task<IActionResult> TestPythonHash([FromBody] List<int> questionOptionIds)
        {
            try
            {
                Console.WriteLine($"🐍 [PYTHON-TEST] Testing combination: [{string.Join(", ", questionOptionIds)}]");
               
                // Replicar la lógica de Python exactamente
                var sortedIds = questionOptionIds.OrderBy(x => x).ToList();
                var hashInput = string.Join(",", sortedIds);
               
                Console.WriteLine($"🔧 [PYTHON-TEST] Sorted IDs: [{string.Join(", ", sortedIds)}]");
                Console.WriteLine($"🔧 [PYTHON-TEST] Hash input: '{hashInput}'");
               
                string generatedHash;
                using (var sha256 = SHA256.Create())
                {
                    var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
                    generatedHash = Convert.ToHexString(hashBytes).ToLower();
                }
               
                Console.WriteLine($"🔑 [PYTHON-TEST] Generated hash: {generatedHash}");
               
                // Buscar en la BD
                var destination = await _service.GetDestinationByCombination(generatedHash);
               
                // Obtener algunos hashes de ejemplo de la BD
                var allDestinations = await _service.GetAllDestinationsWithCities();
                var sampleHashes = allDestinations.Take(5).Select(d => new
                {
                    Id = d.Id,
                    Hash = d.Combination,
                    HashPreview = d.Combination.Substring(0, 16) + "...",
                    FirstCity = d.FirstCity?.Description,
                    SecondCity = d.SecondCity?.Description
                }).ToList();
               
                return Ok(new
                {
                    Input = new
                    {
                        OriginalIds = questionOptionIds,
                        SortedIds = sortedIds,
                        HashInput = hashInput,
                        GeneratedHash = generatedHash.Substring(0, 16) + "...",
                        FullGeneratedHash = generatedHash
                    },
                    Result = new
                    {
                        Found = destination != null,
                        Destination = destination != null ? new
                        {
                            Id = destination.Id,
                            FirstCity = destination.FirstCity?.Description,
                            SecondCity = destination.SecondCity?.Description
                        } : null
                    },
                    Debug = new
                    {
                        TotalDestinationsInDB = allDestinations.Count(),
                        SampleHashesFromDB = sampleHashes
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [PYTHON-TEST] Error: {ex.Message}");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
 
        [HttpPost("debug/find-by-hash")]
        public async Task<IActionResult> FindByHash([FromBody] string hash)
        {
            try
            {
                Console.WriteLine($"🔍 [HASH-SEARCH] Buscando hash directo: {hash.Substring(0, 16)}...");
               
                var destination = await _service.GetDestinationByCombination(hash);
               
                if (destination == null)
                {
                    Console.WriteLine("❌ [HASH-SEARCH] No encontrado");
                    return NotFound($"No se encontró destino para hash: {hash.Substring(0, 16)}...");
                }
               
                Console.WriteLine($"✅ [HASH-SEARCH] Encontrado: {destination.FirstCity?.Description} + {destination.SecondCity?.Description}");
               
                return Ok(new
                {
                    Found = true,
                    Destination = new
                    {
                        Id = destination.Id,
                        Hash = destination.Combination,
                        FirstCity = destination.FirstCity?.Description,
                        SecondCity = destination.SecondCity?.Description
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
 