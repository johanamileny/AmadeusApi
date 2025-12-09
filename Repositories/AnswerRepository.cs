using AmadeusApi.Models;
using AmadeusApi.Contracts;
using AmadeusApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AmadeusDbContext _context;

        public AnswerRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> CreateAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<List<Answer>> GetByUserIdAsync(int userId)
        {
            return await _context.Answers
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }

        public async Task<List<UserAnswerStatsDto>> GetUserAnswerStatsAsync()
        {
            await Task.CompletedTask;
            return new List<UserAnswerStatsDto>();
        }

        public async Task<UserAnswerStatsDto?> GetUserAnswerStatsAsync(int userId)
        {
            await Task.CompletedTask;
            return null;
        }

        public async Task<OverallStatsDto> GetOverallStatsAsync()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalAnswers = await _context.Answers.CountAsync();
            var totalQuestions = await _context.Questions.CountAsync();

            return new OverallStatsDto
            {
                TotalUsers = totalUsers,
                TotalAnswers = totalAnswers,
                TotalQuestions = totalQuestions
            };
        }

        public async Task<List<DailyActivityDto>> GetDailyActivityStatsAsync(int days = 30)
        {
            await Task.CompletedTask;
            return new List<DailyActivityDto>();
        }

        public async Task<List<PopularDestinationDto>> GetPopularDestinationsAsync()
        {
            await Task.CompletedTask;
            return new List<PopularDestinationDto>();
        }

        public async Task<List<Answer>> GetAnswersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Sin AnsweredAt: devolvemos por Id como aproximación
            return await _context.Answers
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }

        public async Task<List<Answer>> GetAnswersByQuestionAsync(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }
    }
}