using AmadeusApi.Data;
using AmadeusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class QuestionOptionRepository
    {
        private readonly AmadeusDbContext _context;

        public QuestionOptionRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionOption>> GetAllAsync()
        {
            return await _context.QuestionOptions.ToListAsync();
        }

        public async Task<QuestionOption?> GetByIdAsync(int id)
        {
            return await _context.QuestionOptions.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<QuestionOption>> GetByQuestionIdAsync(int questionId)
        {
            return await _context.QuestionOptions
                .Where(o => o.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<QuestionOption> AddAsync(QuestionOption option)
        {
            _context.QuestionOptions.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }

        public async Task<QuestionOption> UpdateAsync(QuestionOption option)
        {
            _context.QuestionOptions.Update(option);
            await _context.SaveChangesAsync();
            return option;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var opt = await _context.QuestionOptions.FindAsync(id);
            if (opt == null) return false;
            _context.QuestionOptions.Remove(opt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}