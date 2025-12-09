using AmadeusApi.Models;
using AmadeusApi.Repositories;

namespace AmadeusApi.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            return await _answerRepository.CreateAsync(answer);
        }

        public Task<List<Answer>> GetUserAnswersAsync(int userId) =>
            _answerRepository.GetByUserIdAsync(userId);
    }
}