using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity
{
    public class UpdateEntityModel
    {
        private decimal _price = 0;
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get => _price; set => _price = value; }
        public DateTime Created { get; set; }

    }
}
