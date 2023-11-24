using Boilerplate.Application.Common.Constants.Common;

namespace Boilerplate.Application.Common.Exceptions
{
    public class SearchTableFieldErrorException : BaseApplicationException
    {
        public SearchTableFieldErrorException(string field, string message = "BASE_APPLICATION_EXCEPTION") : base()
        {
            string error = $""
                + $"{CommonConstans.SEARCH_ERROR_FIELD_DOES_NOT_EXIST_ON_ENTITY_TABLE} : "
                + $"{CommonConstans.ENIITY_FIELD_NAME} - {field}";

            Errors.Add(CommonConstans.SEARCH_ERROR, new string[] { error });
        }
    }
}
