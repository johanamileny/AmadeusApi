using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class QuestionOptionController : ControllerBase
{
    private readonly QuestionOptionService _service;

    public QuestionOptionController(QuestionOptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questionOptions = await _service.GetAllAsync();
        return Ok(questionOptions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var questionOption = await _service.GetByIdAsync(id);
        if (questionOption == null) return NotFound();
        return Ok(questionOption);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] QuestionOption questionOption)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddAsync(questionOption);
        return CreatedAtAction(nameof(GetById), new { id = questionOption.Id }, questionOption);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] QuestionOption questionOption)
    {
        if (id != questionOption.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.UpdateAsync(questionOption);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var questionOption = await _service.GetByIdAsync(id);
        if (questionOption == null) return NotFound();
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
