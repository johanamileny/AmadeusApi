using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AnswerRepository : IAnswerRepository
{
    private readonly AmadeusDbContext _context;

    public AnswerRepository(AmadeusDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Answer>> GetAllAsync()
    {
        return await _context.Answers.ToListAsync();
    }

    public async Task<Answer?> GetByIdAsync(int id)
    {
       return await _context.Answers
        .AsNoTracking() 
        .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Answer answer)
    {
        await _context.Answers.AddAsync(answer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Answer answer)
    {
        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer != null)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }
}