using outdesk.codingtest.Infrastructure.Data.Entities;

namespace outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces
{
    public interface IReservedBookRepository
    {
        IQueryable<ReservedBook> ReservedBooks();
    }
}
