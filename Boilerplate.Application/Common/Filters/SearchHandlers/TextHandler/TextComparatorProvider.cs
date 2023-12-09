namespace Boilerplate.Application.Common.Filters.SearchHandlers.TextHandler
{
    public static class TextComparatorProvider
    {
        private const string EQUALS = "Equals";
        private const string NOT_EQUAL = "NotEqual";
        private const string CONTAIN = "Contains";

        public static Dictionary<int, string> GetComparator() {
            return new Dictionary<int, string>() { 
                { 1, EQUALS }, 
                { 2, NOT_EQUAL }, 
                { 3, CONTAIN } 
            };
        }
    }
}
