using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly ILogger<AnswerService> _logger; 

    public AnswerService(IAnswerRepository answerRepository, ILogger<AnswerService> logger)
    {
        _answerRepository = answerRepository;
        _logger = logger; 
    }

    public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
    {
        return await _answerRepository.GetAllAsync();
    }

    public async Task<Answer?> GetAnswerByIdAsync(int id)
    {
        return await _answerRepository.GetByIdAsync(id);
    }

    public async Task AddAnswerAsync(Answer answer)
    {
        await _answerRepository.AddAsync(answer);
    }

    public async Task<bool> UpdateAnswerAsync(Answer answer)
    {
        try
        {
            var existingAnswer = await _answerRepository.GetByIdAsync(answer.Id);
            if (existingAnswer == null)
                return false;

            await _answerRepository.UpdateAsync(answer);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Answer"); 
            throw new Exception("Error updating Answer.");
        }
    }

    public async Task<bool> DeleteAnswerAsync(int id)
    {
        try
        {
            var existingAnswer = await _answerRepository.GetByIdAsync(id);
            if (existingAnswer == null)
                return false;

            await _answerRepository.DeleteAsync(id);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting Answer"); 
            throw new Exception("Error deleting Answer.");
        }
    }
}