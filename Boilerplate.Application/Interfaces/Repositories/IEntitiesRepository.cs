using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Domain.Enitities.Entity;

namespace Boilerplate.Application.Interfaces.Repositories
{
    public interface IEntitiesRepository : IGenericRepository<Entity>
    {
        IQueryable<Entity> GetDbSet();
    }
}
