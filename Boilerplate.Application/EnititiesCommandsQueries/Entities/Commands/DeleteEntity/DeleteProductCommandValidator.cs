using FluentValidation;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.DeleteEntity
{
    public class DeleteEntityCommandValidator : AbstractValidator<DeleteEntityCommand>
    {
        public DeleteEntityCommandValidator()
        {
            RuleFor(command => command.Model.Id)
                .NotEmpty();
        }
    }
}
