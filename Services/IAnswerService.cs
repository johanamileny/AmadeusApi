using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAnswerService
{
    Task<IEnumerable<Answer>> GetAllAnswersAsync();
    Task<Answer?> GetAnswerByIdAsync(int id);
    Task AddAnswerAsync(Answer answer);
    Task <bool>UpdateAnswerAsync(Answer answer);
    Task<bool> DeleteAnswerAsync(int id); 

}