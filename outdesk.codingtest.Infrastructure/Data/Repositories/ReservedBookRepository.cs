using outdesk.codingtest.Core.Entities;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;

namespace outdesk.codingtest.Infrastructure.Data.Repositories
{
    public class ReservedBookRepository : IReservedBookRepository
    {
        private readonly OutDeskContext _context;
        public ReservedBookRepository(OutDeskContext context)
        {
            _context = context;
        }
        public IQueryable<ReservedBook> ReservedBooks()
        {
            return _context.ReservedBooks;
        }
    }
}
