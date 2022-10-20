using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhosMessages.Components.Errors
{
    [Serializable]
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() { }
        public InvalidLoginException(string message) : base(message) { }
        public InvalidLoginException(string message, Exception inner) : base(message, inner) { }
        protected InvalidLoginException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class InvalidUsernameException : InvalidLoginException
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }
    }
}
