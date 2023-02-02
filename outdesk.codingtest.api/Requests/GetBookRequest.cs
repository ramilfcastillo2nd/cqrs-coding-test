using MediatR;

namespace outdesk.codingtest.api.Requests
{
    public class GetBookRequest: IRequest
    {
        public string Search { get; set;  }
    }
}
