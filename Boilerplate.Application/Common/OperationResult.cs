namespace Boilerplate.Application.Common
{
    public abstract class OperationResult
    {
        public IDictionary<string, string[]>? Errors { get; set; }
        public bool? Success { get; set; }

        public static OperationResult<TResult> CreateErrorResult<TResult>(IDictionary<string, string[]> errors)
        {
            return new OperationResult<TResult>
            {
                Success = false,
                Errors = errors
            };
        }
        public static OperationResult<TResult> CreateResult<TResult>(TResult result, bool success = true)
        {
            return new OperationResult<TResult>
            {
                Data = result,
                Success = success
            };
        }

        public static OperationResultList<TResult> CreateResultList<TResult>(
            TResult result, 
            PageInfo pageInfo, 
            bool success = true
            )
        {
            return new OperationResultList<TResult>
            {
                Items = result,
                Success = success,
                PageIndex = pageInfo.PageIndex,
                PageSize = pageInfo.PageSize,
                TotalPages = pageInfo.TotalPages,
                Count = pageInfo.Count,
            };
        }

        public static PageInfo GetPageInfoObject(
            int PageIndex,
            int PageSize,
            int TotalPages,
            int Count
            )
        {
            return new PageInfo
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                TotalPages = TotalPages,
                Count = Count
            };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; set; }

    }

    public class PageInfo
    {
        public int PageIndex { get; set;} = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; } = 0;
        public int Count { get; set; } = 0;
    }

    public class OperationResultList<TResult> : OperationResult<TResult>
    {
        public TResult? Items { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; } = 0;
        public int Count { get; set; } = 0;
    }

}
