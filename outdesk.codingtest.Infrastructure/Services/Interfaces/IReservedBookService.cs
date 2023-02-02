namespace outdesk.codingtest.Infrastructure.Services.Interfaces
{
    public interface IReservedBookService
    {
        Task ReserveBook(Guid bookId);
    }
}
