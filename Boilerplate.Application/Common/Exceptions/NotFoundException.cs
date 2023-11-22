using Boilerplate.Application.Common.Constants.Common;

namespace Boilerplate.Application.Common.Exceptions
{
    public class NotFoundException : BaseApplicationException
    {
        public NotFoundException(string operationName, string entityType)
            : base()
        {
            var message = $"{entityType} - " + CommonConstans.ENTITY_NOT_FOUND;
            Errors.Add(operationName, new string[] { message });
        }
    }
}
