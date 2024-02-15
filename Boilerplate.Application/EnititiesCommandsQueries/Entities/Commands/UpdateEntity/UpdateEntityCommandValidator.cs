using FluentValidation;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity
{
    public class UpdateEntityCommandValidator : AbstractValidator<UpdateEntityCommand>
    {
        public UpdateEntityCommandValidator() {

            RuleFor(command => command.Model.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(command => command.Model.Name)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(64);

            RuleFor(command => command.Model.Description)
                .NotEmpty()
                .MinimumLength(64)
                .MaximumLength(256);

        }
    }
}
