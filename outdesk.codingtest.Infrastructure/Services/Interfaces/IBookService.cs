using outdesk.codingtest.Core.DTO;

namespace outdesk.codingtest.Infrastructure.Services.Interfaces
{
    public interface IBookService
    {
        Task<bool> CheckBookExists(string name);
        Task CreateBook(string bookName, Guid id);
        Task<List<BookDto>> GetBooks();
    }
}
