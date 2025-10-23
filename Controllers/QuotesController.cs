using QuotingApi.Models;
using QuotingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace QuotingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuotesController(IQuoteService service)
        {
            _service = service;
        }

        // POST /api/quotes
        [HttpPost]
        public IActionResult Create([FromBody] QuoteRequest request)
        {
            if (request == null || request.Term <= 0 || request.SumInsured <= 0)
                return BadRequest("Invalid quote request.");

            var id = _service.CreateQuote(request);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        // GET /api/quotes/{id}
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var quote = _service.GetQuote(id);
            if (quote == null)
                return NotFound("Quote not found.");

            return Ok(quote);
        }
    }
}
