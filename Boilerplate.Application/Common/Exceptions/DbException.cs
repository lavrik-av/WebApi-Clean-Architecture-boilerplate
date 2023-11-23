using Boilerplate.Application.Common.Constants.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boilerplate.Application.Common.Exceptions
{
    public class DbException : BaseApplicationException
    {
        public DbException(Exception exception)
        {
            string error = $"{exception.Message}";

            if (exception.InnerException is not null)
            {
                error = $"{error} : {exception.InnerException.Message}";
            }

            Errors.Add(CommonConstans.UNEXPECTED_DB_ERROR, new string[] { error });
        }
    }
}
