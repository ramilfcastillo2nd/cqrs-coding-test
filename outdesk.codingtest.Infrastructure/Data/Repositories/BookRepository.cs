using outdesk.codingtest.Infrastructure.Data.Entities;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;

namespace outdesk.codingtest.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly OutDeskContext _context;
        public BookRepository(OutDeskContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books()
        {
            return _context.Books;
        }
    }
}
