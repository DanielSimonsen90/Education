using System;
using System.Runtime.Serialization;


namespace MIG.Exceptions
{
    [Serializable]
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException() { }
        public InvalidKeyException(string message) : base(message) { }
        public InvalidKeyException(string message, Exception inner) : base(message, inner) { }
        protected InvalidKeyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
