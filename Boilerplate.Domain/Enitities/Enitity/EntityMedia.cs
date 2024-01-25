using System.Text.Json.Serialization;

namespace Boilerplate.Domain.Enitities.Entity
{
    public class EntityMedia : IEntity
    {
        [JsonIgnore]
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Entity? Entities { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        [JsonIgnore]
        public string ImageType { get; set; } = string.Empty;
    }
}
