using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    // Obtener todas las respuestas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Answer>>> GetAll()
    {
        var answers = await _answerService.GetAllAnswersAsync();
        return Ok(answers);
    }

    // Obtener respuesta por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
                return NotFound(new { message = "Answer not found" });

            return Ok(answer);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    // Crear nueva respuesta
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Answer answer)
    {
        try
        {
            if (answer == null)
                return BadRequest(new { message = "Invalid request data" });

            await _answerService.AddAnswerAsync(answer); 
            return CreatedAtAction(nameof(GetById), new { id = answer.Id }, answer);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    // Actualizar una respuesta existente
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Answer answer)
    {
        try
        {
            if (answer == null || id != answer.Id)
                return BadRequest(new { message = "Invalid request data" });

            var updated = await _answerService.UpdateAnswerAsync(answer);
            if (!updated)
                return NotFound(new { message = "Answer not found" });

            return Ok(new { message = "Answer updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    // Eliminar una respuesta
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var deleted = await _answerService.DeleteAnswerAsync(id);
            if (!deleted)
                return NotFound(new { message = "Answer not found" });

            return Ok(new { message = "Answer deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }
}