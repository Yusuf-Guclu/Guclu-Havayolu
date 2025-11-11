using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Havayolu.Models;
using System;

namespace Havayolu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IGroqService _groqService;

        public QuestionsController(IGroqService groqService)
        {
            _groqService = groqService;
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] QuestionModel question)
        {
            try
            {
                var response = await _groqService.AskQuestion(question.Question);
                return Ok(new { answer = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
} 