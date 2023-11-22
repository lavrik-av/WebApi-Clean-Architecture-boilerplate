using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.DeleteProduct
{
    public class DeleteProductModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
