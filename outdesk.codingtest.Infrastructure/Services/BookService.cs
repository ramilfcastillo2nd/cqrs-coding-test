using AutoMapper;
using Microsoft.EntityFrameworkCore;
using outdesk.codingtest.Core.DTO;
using outdesk.codingtest.Infrastructure.Data.Entities;
using outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces;
using outdesk.codingtest.Infrastructure.Services.Interfaces;

namespace outdesk.codingtest.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CheckBookExists(string name)
        {
           var books  = await _repository.Books().AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (books == null)
                return false;
            else
                return true;
        }
        public async Task CreateBook(string bookName, Guid id)
        {
            _unitOfWork.Repository<Book>().Add(new Book {
                Id = id,
                Name = bookName,
            });
            await _unitOfWork.Complete();
        }

        public async Task<List<BookDto>> GetBooks()
        {
            var books = await _repository.Books().AsNoTracking().ToListAsync();
            var booksMapped  = _mapper.Map<List<BookDto>>(books);
            return booksMapped;
        }
    }
}
