using outdesk.codingtest.Core.Entities;

namespace outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> Books();
    }
}
