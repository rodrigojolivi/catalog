namespace Catalog.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
