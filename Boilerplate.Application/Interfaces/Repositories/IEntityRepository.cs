using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Domain.Enitities.Entity;

namespace Eshop.Application.Interfaces.Repositories
{
    public interface IEntityRepository : IGenericRepository<Entity>
    {
        IQueryable<Entity> GetDbSet();
    }
}
