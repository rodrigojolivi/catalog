using Catalog.Core.Domain.Repositories;
using Catalog.Infrastructure.Persistence.Contexts;

namespace Catalog.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _context;

        public UnitOfWork(CatalogContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
