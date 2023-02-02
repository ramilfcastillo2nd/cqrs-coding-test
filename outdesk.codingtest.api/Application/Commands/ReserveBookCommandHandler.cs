using MediatR;
using outdesk.codingtest.api.Requests;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.api.Application.Commands
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookRequest>
    {
        private readonly IReservedBookService _reservedBookService;
        public ReserveBookCommandHandler(IReservedBookService reservedBookService)
        {
            _reservedBookService = reservedBookService;
        }
        public async Task<Unit> Handle(ReserveBookRequest request, CancellationToken cancellationToken)
        {
            await _reservedBookService.ReserveBook(request.BookId);
            return Unit.Value;
        }
    }
}
