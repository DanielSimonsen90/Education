using System;
using System.Runtime.Serialization;

namespace MIG.Song
{
    [Serializable]
    internal class InvalidBPMValueException : Exception
    {
        public InvalidBPMValueException()
        {
        }

        public InvalidBPMValueException(string message) : base(message)
        {
        }

        public InvalidBPMValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBPMValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}