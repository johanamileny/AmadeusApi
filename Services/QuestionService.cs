using Amadeus.Models;
using Amadeus.Repositories;

public class QuestionService
{
    // Inyeccion de dependencias (Depende del repositorio)
    private readonly QuestionRepository _questionRepository;

    public QuestionService(QuestionRepository questionRepository)
    {
        _questionRepository  = questionRepository;
    }


    // TODO Read
    public async Task<IEnumerable<Question>> GetAll()
    {
        return await _questionRepository.GetAll();
    }

    public async Task<Question> GetQuestionId(int id)
    {
        try
        {
            return await _questionRepository.GetQuestionId(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Question> GetQuestionText(string question_text)
    {
        try
        {
            return await _questionRepository.GetQuestionText(question_text);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }




    // TODO Create
    public async Task<Question> CreateQuestion(Question question)
    {
        try
        {
            return await _questionRepository.CreateQuestions(question);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }


    // TODO Update
    public async Task<Question> UpdateQuestion(Question question)
    {
        try
        {
            return await _questionRepository.UpdateQuestion(question);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    // TODO Delete
    public async Task<Question> DeleteQuestion(int id)
    {
        // Comprobar que exista
        var user = await _questionRepository.GetQuestionId(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        try
        {
            return await _questionRepository.DeleteQuestion(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}