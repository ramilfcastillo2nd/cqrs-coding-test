using Microsoft.EntityFrameworkCore;
using outdesk.codingtest.Core.Entities;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.Infrastructure.Services
{
    public class ReservedBookService : IReservedBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservedBookRepository _reservedBookRepository;
        public ReservedBookService(IUnitOfWork unitOfWork, IReservedBookRepository reservedBookRepository)
        {
            _unitOfWork = unitOfWork;
            _reservedBookRepository = reservedBookRepository;
        }

        public async Task ReserveBook(Guid bookId)
        {
            var reservedBook = await _reservedBookRepository.ReservedBooks().AsNoTracking().FirstOrDefaultAsync(x => x.BookId == bookId);
            if (reservedBook != null)
                throw new Exception("Book is already reserved!");

            var book = await _reservedBookRepository.ReservedBooks().AsNoTracking().OrderByDescending(x => x.BookingNumber).FirstOrDefaultAsync();
            var bookingNumber = 1;
            if (book != null)
                bookingNumber = book.BookingNumber + 1;

            _unitOfWork.Repository<ReservedBook>().Add(new ReservedBook { 
                BookId = bookId,
                BookingNumber = bookingNumber
            });
            await _unitOfWork.Complete();
        }
    }
}
