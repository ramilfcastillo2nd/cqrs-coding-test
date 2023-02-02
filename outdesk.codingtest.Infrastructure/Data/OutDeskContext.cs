using Microsoft.EntityFrameworkCore;
using outdesk.codingtest.Infrastructure.Data.Entities;

namespace outdesk.codingtest.Infrastructure.Data
{
    public class OutDeskContext: DbContext
    {
        public OutDeskContext(DbContextOptions<OutDeskContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReservedBook> ReservedBooks { get; set; }
    }
}
