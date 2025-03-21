using Amadeus.Models;
using Microsoft.AspNetCore.Mvc;


namespace Amadeus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    // Inyeccion de dependencias (Depende del servicio)
    private readonly QuestionService _questionService;

    public QuestionController(QuestionService questionService)
    {
        _questionService = questionService;
    }


    // TODO Read
    // GET: api/User
    [HttpGet]
    public async Task<IEnumerable<Question>> GetAll()
    {
        return await _questionService.GetAll();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<Question> GetUserId(int id)
    {
        return await _questionService.GetQuestionId(id);
    }

    // GET: api/User/5
    [HttpGet("/questiontext/{question_text}")]
    public async Task<Question> GetQuestiontext(string question_text)
    {
        return await _questionService.GetQuestionText(question_text);
    }


    // TODO Create
    // POST: api/User
    [HttpPost]
    public async Task<Question> CreateQuestion(Question question)
    {
        return await _questionService.CreateQuestion(question);
    }


    // TODO Update
    // PUT: api/User/5
    [HttpPut("{id}")]
    public async Task<Question> UpdateQuestion(Question question)
    {
        return await _questionService.UpdateQuestion(question);
    }


    // TODO Delete
    // DELETE: api/Question/5
    [HttpDelete("{id}")]
    public async Task<Question> DeleteQuestion(int id)
    {
        return await _questionService.DeleteQuestion(id);
    }

      
}