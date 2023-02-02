using MediatR;
using outdesk.codingtest.api.Requests;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.api.Application.Commands
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookRequest>
    {
        private readonly IBookService _bookService;
        public ReserveBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public Task<Unit> Handle(ReserveBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
