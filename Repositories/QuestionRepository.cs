using AmadeusApi.Data;
using AmadeusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class QuestionRepository
    {
        private readonly AmadeusDbContext _context;

        public QuestionRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        // Llamado por QuestionService.GetAll
        public async Task<List<Question>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        // Llamado por QuestionService.GetQuestionId
        public async Task<Question?> GetQuestionId(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        // Llamado por QuestionService.GetQuestionText
        public async Task<Question?> GetQuestionText(string text)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.QuestionText == text);
        }

        // Llamado por QuestionService.CreateQuestions
        public async Task<Question> CreateQuestions(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        // Llamado por QuestionService.UpdateQuestion
        public async Task<Question> UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        // Llamado por QuestionService.DeleteQuestion
        public async Task<Question?> DeleteQuestion(int id)
        {
            var q = await _context.Questions.FindAsync(id);
            if (q == null) return null;
            _context.Questions.Remove(q);
            await _context.SaveChangesAsync();
            return q;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                .Include(q => q.QuestionOptions)
                .OrderBy(q => q.Order)
                .ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.QuestionOptions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await GetByIdAsync(id);
            if (question == null) return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Question>> GetRandomQuestionsAsync(int count)
        {
            return await _context.Questions
                .Include(q => q.QuestionOptions)
                .OrderBy(q => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
        }
    }
}