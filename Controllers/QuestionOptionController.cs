using Amadeus.Services;
using Amadeus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmadeusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionOptionController : ControllerBase
    {
        private readonly QuestionOptionService _questionOptionService;

        public QuestionOptionController(QuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questionOptions = await _questionOptionService.GetAllAsync();
            return Ok(questionOptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var questionOption = await _questionOptionService.GetByIdAsync(id);
            if (questionOption == null) return NotFound();
            return Ok(questionOption);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] QuestionOption questionOption)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _questionOptionService.AddAsync(questionOption);
            return CreatedAtAction(nameof(GetById), new { id = questionOption.Id }, questionOption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionOption questionOption)
        {
            if (id != questionOption.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _questionOptionService.UpdateAsync(questionOption);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var questionOption = await _questionOptionService.GetByIdAsync(id);
            if (questionOption == null) return NotFound();
            await _questionOptionService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ByQuestion/{questionId}")]
        public async Task<ActionResult<IEnumerable<QuestionOption>>> GetByQuestionId(int questionId)
        {
            try
            {
                var options = await _questionOptionService.GetOptionsByQuestionIdAsync(questionId);
                
                if (options == null || !options.Any())
                {
                    return NotFound($"No options found for question with ID: {questionId}");
                }
                
                return Ok(options);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
