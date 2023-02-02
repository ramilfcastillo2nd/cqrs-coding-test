using outdesk.codingtest.Core.Entities;

namespace outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces
{
    public interface IReservedBookRepository
    {
        IQueryable<ReservedBook> ReservedBooks();
    }
}
