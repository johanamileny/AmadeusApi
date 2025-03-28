using Amadeus.Models;
using Amadeus.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amadeus.Services
{
    public class QuestionOptionService
    {
        private readonly QuestionOptionRepository _repository;

        public QuestionOptionService(QuestionOptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionOption>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<QuestionOption> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuestionOption questionOption)
        {
            await _repository.AddAsync(questionOption);
        }

        public async Task UpdateAsync(QuestionOption questionOption)
        {
            await _repository.UpdateAsync(questionOption);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<QuestionOption>> GetOptionsByQuestionIdAsync(int questionId)
        {
            return await _repository.GetByQuestionIdAsync(questionId);
        }
    }
}
