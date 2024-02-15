using System.Text.Json.Serialization;

namespace Boilerplate.Domain.Enitities.Entity
{
    public class Entity : IEntity
    {
        private decimal _price = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get => _price; set => _price = value; }
        public bool Published { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public int Quantity { get; set; } = 0;
        [JsonIgnore]
        public List<EntityMedia>? EntityMedia { get; set; }
    }
}
