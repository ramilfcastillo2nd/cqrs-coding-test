using outdesk.codingtest.Infrastructure.Data.Entities;

namespace outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> Books();
    }
}
