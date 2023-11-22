namespace Boilerplate.Application.Common
{
    public abstract class PagedList 
    { 
        public static PagedList<TEntity> ToPagedList<TEntity>(IList<TEntity> items, int totalCount = 0, int totalPagesCount = 0)
        { 
            return new PagedList<TEntity>(items, totalCount, totalPagesCount); 
        }
    }

    public class PagedList<TEntity> : PagedList
    { 
        public IList<TEntity> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPagesCount { get; set; }

        public PagedList(IList<TEntity> items, int totalCount, int totalPagesCount)
        {
            Items = items;
            TotalCount = totalCount;
            TotalPagesCount = totalPagesCount;
        }
    }

}
