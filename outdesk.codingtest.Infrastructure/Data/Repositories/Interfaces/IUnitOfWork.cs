using outdesk.codingtest.Core.Entities;

namespace outdesk.codingtest.Infrastructure.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
