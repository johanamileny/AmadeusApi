using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amadeus.Repositories;

public interface IAnswerRepository
{
    Task<IEnumerable<Answer>> GetAllAsync();
    Task<Answer?> GetByIdAsync(int id);
    Task AddAsync(Answer answer);
    Task UpdateAsync(Answer answer);
    Task DeleteAsync(int id);
}