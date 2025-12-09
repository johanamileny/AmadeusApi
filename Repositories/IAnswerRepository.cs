using System.Collections.Generic;
using System.Threading.Tasks;
using AmadeusApi.Data;
using AmadeusApi.Models;
using AmadeusApi.Contracts;

namespace AmadeusApi.Repositories
{
    public interface IAnswerRepository
    {
        Task<Answer> CreateAsync(Answer answer);
        Task<List<Answer>> GetByUserIdAsync(int userId);
        Task<List<UserAnswerStatsDto>> GetUserAnswerStatsAsync();
        Task<UserAnswerStatsDto?> GetUserAnswerStatsAsync(int userId);
        Task<OverallStatsDto> GetOverallStatsAsync();
        Task<List<DailyActivityDto>> GetDailyActivityStatsAsync(int days = 30);
        Task<List<PopularDestinationDto>> GetPopularDestinationsAsync();
        Task<List<Answer>> GetAnswersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Answer>> GetAnswersByQuestionAsync(int questionId);
    }
}