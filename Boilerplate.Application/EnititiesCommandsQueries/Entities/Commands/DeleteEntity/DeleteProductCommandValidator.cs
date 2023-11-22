using FluentValidation;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Model.Id)
                .NotEmpty();
        }
    }
}
