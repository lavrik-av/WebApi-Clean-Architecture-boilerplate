using Boilerplate.Application.Common.Constants.Common;

namespace Boilerplate.Application.Common.Exceptions
{
    public class WrongRequestModelFieldsException : BaseApplicationException
    {
        public WrongRequestModelFieldsException(string entityType) 
            : base()
        {
            Errors.Add(entityType, new string[] { CommonConstans.MISSING_REQUIRED_FIELDS });
        }
    }
}
