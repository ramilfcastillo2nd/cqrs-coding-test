using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using outdesk.codingtest.api.Errors;
using outdesk.codingtest.api.Requests;
using outdesk.codingtest.Core.DTO;
using outdesk.codingtest.Core.Specifications;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;
        public BookStoreController(IMediator mediator, IBookService bookService)
        {
            _mediator = mediator;
            _bookService = bookService;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooks([FromQuery] BookSpecParams request)
        {
            //var req = new GetBookRequest
            //{
            //    Search = request.Search
            //};

            //var results = await _mediator.Send(req);
            var results = await _bookService.GetBooks(request);

            return Ok(results);
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] ReserveBookRequestDto request)
        {
            try
            {
                var req = new ReserveBookRequest
                {
                    BookId = request.BookId
                };

                var results = await _mediator.Send(req);

                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(new ApiResponse(400, x.Message));
            }
        }
    }
}
