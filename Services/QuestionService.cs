using AmadeusApi.Models;
using AmadeusApi.Repositories;

namespace AmadeusApi.Services
{
    public class QuestionService
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionService(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Task<List<Question>> GetAll() =>
            _questionRepository.GetAll();

        public Task<Question?> GetQuestionId(int id) =>
            _questionRepository.GetQuestionId(id);

        public Task<Question?> GetQuestionText(string text) =>
            _questionRepository.GetQuestionText(text);

        // Alias requerido por el controlador
        public Task<Question> CreateQuestion(Question q) =>
            _questionRepository.CreateQuestions(q);

        public Task<Question> CreateQuestions(Question q) =>
            _questionRepository.CreateQuestions(q);

        public Task<Question> UpdateQuestion(Question q) =>
            _questionRepository.UpdateQuestion(q);

        // Ahora devuelve la entidad eliminada (o null)
        public Task<Question?> DeleteQuestion(int id) =>
            _questionRepository.DeleteQuestion(id);
    }
}