using Boilerplate.Application.Interfaces;

namespace Boilerplate.Application.Dto.Entity
{
    public class UpdateEntityDto : IEntityDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public bool Published { get; set; } = true;
        public DateTime Created { get; set; }

    }
}
