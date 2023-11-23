using Boilerplate.Application.EnititiesCommandsQueries.ComplexQuery.Queries;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<ComplexQueryModel> QueryEntities { get; set; }
        void Dispose();
    }
}
