namespace Boilerplate.Application.EnititiesCommandsQueries.ComplexQuery.Queries
{
    public class ComplexQueryModel
    {
        //public string OrderNumber { get; set; } = String.Empty;
        //public int ProductsCount { get; set; } = 0;
        //public string Customer { get; set; } = String.Empty;
        //public decimal Summary { get; set; } = 0;

        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int ProductsCount { get; set; } = 0;
        public string Customer { get; set; } = string.Empty;
        public decimal? Summary { get; set; }
    }
}
