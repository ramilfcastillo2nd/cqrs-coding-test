using outdesk.codingtest.Core.DTO;
using outdesk.codingtest.Core.Specifications;

namespace outdesk.codingtest.Infrastructure.Services.Interfaces
{
    public interface IBookService
    {
        Task<bool> CheckBookExists(string name);
        Task CreateBook(string bookName, Guid id);
        Task<IReadOnlyList<BookDto>> GetBooks(BookSpecParams specParams);
    }
}
