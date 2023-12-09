namespace Boilerplate.Application.Common.Filters.SearchHandlers.DatesHandler
{
    public class DatesComparatorProvider
    {
        private const string EQUALS = "Equals";
        private const string NOT_EQUAL = "NotEqual";
        private const string GREATER_THAN = "GreaterThan";
        private const string GREATER_THAN_OR_EQUAL = "GreaterThanOrEqual";
        private const string LESS_THAN = "LessThan";
        private const string LESS_THAN_OR_EQUAL = "LessThanOrEqual";

        public static Dictionary<int, string> GetComparator()
        {
            return new Dictionary<int, string>() {
                { 1, EQUALS },
                { 2, NOT_EQUAL },
                { 3, GREATER_THAN },
                { 4, GREATER_THAN_OR_EQUAL },
                { 5, LESS_THAN },
                { 6, LESS_THAN_OR_EQUAL }
            };
        }
    }
}
