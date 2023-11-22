using Boilerplate.Application.Common.Constants.Common;

namespace Boilerplate.Application.Common.Exceptions
{
    public abstract class BaseApplicationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

        public BaseApplicationException(string message = CommonConstans.BASE_APPLICATION_EXCEPTION)
            : base(message)
        { }

    }
}
