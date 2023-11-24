using Boilerplate.Application.Common.Constants.Common;

namespace Boilerplate.Application.Common.Exceptions
{
    public class SearchException : BaseApplicationException
    {
        public SearchException(string paramName, string message = "BASE_APPLICATION_EXCEPTION") : base(message)
        {
            Errors.Add(CommonConstans.SEARCH_ERROR, new string[] { $"{message} : {paramName}" });
        }
    }
}
