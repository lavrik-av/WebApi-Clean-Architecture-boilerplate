using FluentValidation.Results;

namespace Boilerplate.Application.Common.Exceptions
{
    public class ValidationException : BaseApplicationException
    {
        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
            :base()
        {
            Errors = validationFailures
                .GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
                .ToDictionary(group => group.Key, group => group.ToArray());
        }
    }
}
