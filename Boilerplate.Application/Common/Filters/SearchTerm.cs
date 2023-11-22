namespace Boilerplate.Application.Common.Filters
{
    public class SearchTerm
    {
        public string Field { get; set; } = string.Empty;
        public string Term { get; set; } = string.Empty;
        public string? TermAdd { get; set; } = string.Empty;
        public int Comparator { get; set; } = 1;
    }
}
