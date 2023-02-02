using MediatR;

namespace outdesk.codingtest.api.Requests
{
    public class ReserveBookRequest:IRequest
    {
        public Guid BookId { get; set; }
    }
}
