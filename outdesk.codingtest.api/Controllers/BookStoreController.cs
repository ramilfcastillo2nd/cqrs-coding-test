using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using outdesk.codingtest.api.Requests;
using outdesk.codingtest.Core.Specifications;

namespace outdesk.codingtest.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookStoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooks([FromQuery] BookSpecParams request)
        {
            if (!string.IsNullOrEmpty(request.Search))
            {
                var req = new GetBookRequest
                {
                    Search = request.Search
                };

                var results = await _mediator.Send(request);
            }
            return null;
        }
    }
}
