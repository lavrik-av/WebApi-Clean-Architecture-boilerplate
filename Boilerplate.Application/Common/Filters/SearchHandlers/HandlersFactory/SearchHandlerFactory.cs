namespace Boilerplate.Application.Common.Filters.SearchHandlers.HandlersFactory
{
    internal static class SearchHandlerFactory
    {
        internal static BaseSearchHandler GetSearchHandler(SearchTerm searchTerm)
        {
            string field = searchTerm.Field.ToUpper();

            if (SearchHandlerTypes.Handlers.ContainsKey(FieldsTypes.FieldType[field]))
            {
                BaseSearchHandler handler = SearchHandlerTypes.Handlers[FieldsTypes.FieldType[field]];

                handler.SetHanlerSearchTerms(searchTerm);

                return handler;
            }

            //TODO: Replace by a constant
            throw new NotImplementedException($"Search handler for the given field type isn't implemented yet. DB field: {searchTerm.Field.ToUpper()}");
        }
    }
}
