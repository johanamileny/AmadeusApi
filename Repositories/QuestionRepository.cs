using Amadeus.Models;
using Microsoft.EntityFrameworkCore;

namespace Amadeus.Repositories;

public class QuestionRepository
{
    // Inyeccion de dependencias (Depende del contexto de la base de datos)
    private readonly AmadeusDbContext _context;

    public QuestionRepository(AmadeusDbContext context)
    {
        _context = context;
    }

    // TODO Read
    public async Task<IEnumerable<Question>> GetAll()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<Question> GetQuestionId(int id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<Question> GetQuestionText(string question_text)
    {
        return await _context.Questions.FirstOrDefaultAsync(x => x.Question_text == question_text);
    }

   


    // TODO Create
    public async Task<Question> CreateQuestions(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }


    // TODO Update
    public async Task<Question> UpdateQuestion(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
        return question;
    }


    // TODO Delete
    public async Task<Question> DeleteQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return    question;}
}