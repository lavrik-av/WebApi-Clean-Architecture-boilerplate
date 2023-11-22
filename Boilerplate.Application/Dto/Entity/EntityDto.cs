using Boilerplate.Application.Interfaces;

namespace Boilerplate.Application.Dto.Entity
{
    public class EntityDto : IEntityDto
    {
        private decimal _price = 0;
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get => _price; set => _price = value; }
        public int Quantity { get; set; } = 0;
        public List<EntityMediaDto>? ProductMedia { get; set; }
        public DateTime Created { get; set; }
    }
}
