namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateEntityModel
    {
        private decimal _price = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get => _price; set => _price = value; }
        public bool Published { get; set; } = true;

    }
}
