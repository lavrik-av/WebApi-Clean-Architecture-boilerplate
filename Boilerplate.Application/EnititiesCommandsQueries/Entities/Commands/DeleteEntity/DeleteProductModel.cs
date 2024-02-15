using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.DeleteEntity
{
    public class DeleteEntityModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
