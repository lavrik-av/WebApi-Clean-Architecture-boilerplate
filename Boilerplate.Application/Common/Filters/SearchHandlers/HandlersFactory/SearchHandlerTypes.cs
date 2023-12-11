using Boilerplate.Application.Common.Filters.SearchHandlers.BooleanHandler;
using Boilerplate.Application.Common.Filters.SearchHandlers.DatesHandler;
using Boilerplate.Application.Common.Filters.SearchHandlers.IntegerHandler;
using Boilerplate.Application.Common.Filters.SearchHandlers.NumericHandler;
using Boilerplate.Application.Common.Filters.SearchHandlers.TextHandler;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.HandlersFactory
{
    internal static class SearchHandlerTypes
    {
        internal static Dictionary<Type, BaseSearchHandler> Handlers { get; } = new Dictionary<Type, BaseSearchHandler>()
        {
            {typeof(string), new TextSearchHandler() },
            {typeof(int), new IntegerSearchHandler() },
            {typeof(decimal), new NumericSearchHandler() },
            {typeof(DateTime), new DatesSearchHandler() },
            {typeof(bool), new BooleanSearchHandler() }
        };
    }
}
