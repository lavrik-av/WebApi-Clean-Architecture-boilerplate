using FluentValidation;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateEntityCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor<string>(createProductCommand => createProductCommand.Model.Name)
                .NotEmpty().MinimumLength(6).MaximumLength(64);

            RuleFor(createProductCommand => createProductCommand.Model.Description)
                .NotEmpty().MinimumLength(16).MaximumLength(256);

            RuleFor(createProductCommand => createProductCommand.Model.Sku)
                .NotEmpty().MinimumLength(3).MaximumLength(6);

            RuleFor(createProductCommand => createProductCommand.Model.Price)
                .GreaterThanOrEqualTo(0)
                .LessThan(1000);
        }
    }
}
