using Microsoft.EntityFrameworkCore;
using Boilerplate.Persistence.Data;
using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Application.Common.Extensions;
using Boilerplate.Application.Common.Filters;
using Microsoft.EntityFrameworkCore.Query;
using Boilerplate.Application.Common.Filters.AuxParams;
using Boilerplate.Application.Interfaces;

namespace Boilerplate.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ApplicationDbContext _context;

        protected DbSet<TEntity> _dBSet;

        private readonly Type _repositoryType;

        public Type RepositoryType { get { return _repositoryType; } }

        // TODO Add Logger
        // private readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dBSet = _context.Set<TEntity>();
            _repositoryType = typeof(TEntity);
        }

        public IQueryable<TEntity> GetDbSet()
        {
            return _dBSet.AsQueryable();
        }

        public DbSet<TEntity> GetDbSetForRawSql()
        {
            return _dBSet;
        }

        public IApplicationDbContext GetDbContext()
        {
            return _context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var newEntity = await _dBSet.AddAsync(entity, cancellationToken);
            return newEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dBSet.FindAsync(new object[] { id });

            if (entity != null)
            {
                _dBSet.Remove(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? IncludeAux = null
            )
        {
            IQueryable<TEntity> query = _dBSet;

            if (Include != null)
            {
                query = Include(query);
            }

            if (IncludeAux != null) 
            { 
                query = IncludeAux(query); 
            }

            return await query.ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllPagedAsync(
            int pageIndex, 
            int pageSize,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null
            )
        {

            IQueryable<TEntity> query = _dBSet;

            if (Include is not null)
            {
                query = Include(query);
            }

            if (OrderBy is not null) {
                query = OrderBy(query);
            }

            return await query              
                .Skip(pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dBSet.FindAsync(new object[] { id });
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public Task<Guid> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var result = _dBSet.Update(entity);
            return Task.FromResult((Guid)result.Entity.GetType().GetProperty("Id").GetValue(result.Entity));
        }

        public async Task<IList<TEntity>> Search(IList<SearchTerm> filters)
        {
            var entities = await _dBSet
                // .ApplyFilters(filters) TODO Uncomment it while working on the project
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task<IList<TEntity>> SearchExt(AuxParams auxParams)
        {
            IQueryable<TEntity> query = _dBSet;

            if (auxParams.SearchTerms.Any())
            {
                query = query.ApplyFiltersAux(auxParams.SearchTerms);
            }

            if (auxParams.IncludeParam is not null && auxParams.IncludeParam.Any())
            {
                foreach (var navigationField in auxParams.IncludeParam)
                {
                    query = query.Include(navigationField);
                }
            }

            if (auxParams.SortingParam is not null)
            {
                query = query.OrderBy(
                    auxParams.SortingParam.Name,
                    auxParams.SortingParam.Direction.ToUpper() == SortingConstants.DESC ? false : true
                    );
            }

            if (auxParams.PaginationParam?.PageSize != null && auxParams.PaginationParam?.PageIndex != null)
            {
                query = query
                    .Skip((int)auxParams.PaginationParam.PageSize * (int)auxParams.PaginationParam.PageIndex)
                    .Take((int)auxParams.PaginationParam.PageSize);
            }
            else
            {
                throw new NotImplementedException("RETURN_ITEMS_AMOUNT_NOT_SET");
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
