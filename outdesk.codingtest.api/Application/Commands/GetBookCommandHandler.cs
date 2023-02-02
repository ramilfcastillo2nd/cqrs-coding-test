using MediatR;
using outdesk.codingtest.api.Requests;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.api.Application.Commands
{
    public class GetBookCommandHandler: IRequestHandler<GetBookRequest>
    {

        private readonly IBookService _bookService;
        public GetBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Unit> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
