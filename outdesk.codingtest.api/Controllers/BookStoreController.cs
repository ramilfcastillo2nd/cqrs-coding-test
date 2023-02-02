using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using outdesk.codingtest.api.Requests;
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
            var results = await _bookService.GetBooks();

            return Ok(results);
        }
    }
}
