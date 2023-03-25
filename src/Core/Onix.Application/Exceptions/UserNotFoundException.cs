using System.Runtime.Serialization;

namespace Onix.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(message: Onix.Application.Constants.Message.UserNotFound)
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
