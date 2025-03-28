using Microsoft.EntityFrameworkCore;

namespace Amadeus.Repositories;

public class QuestionOptionRepository
{
    private readonly AmadeusDbContext _context;

    public QuestionOptionRepository(AmadeusDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<QuestionOption>> GetAllAsync()
    {
        return await _context.QuestionOptions.ToListAsync();
    }

    public async Task<QuestionOption> GetByIdAsync(int id)
    {
        var questionOption = await _context.QuestionOptions.FindAsync(id);
        if (questionOption == null)
        {
            throw new KeyNotFoundException($"QuestionOption with id {id} not found.");
        }
        return questionOption;
    }

    public async Task AddAsync(QuestionOption questionOption)
    {
        await _context.QuestionOptions.AddAsync(questionOption);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(QuestionOption questionOption)
    {
        _context.QuestionOptions.Update(questionOption);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var questionOption = await _context.QuestionOptions.FindAsync(id);
        if (questionOption != null)
        {
            _context.QuestionOptions.Remove(questionOption);
            await _context.SaveChangesAsync();
        }
    }
}
