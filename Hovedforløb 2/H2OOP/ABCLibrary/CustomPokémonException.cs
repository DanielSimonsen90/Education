using ABCLibrary.Interfaces;
using System;

namespace ABCLibrary
{
    [Serializable]
    public class PokémonException : Exception
    {
        protected ITeamMember ErrorCaller { get; }
        public PokémonException(string message, ITeamMember e) : base(message) => ErrorCaller = e;
    }

    [Serializable]
    public class NoTypingsException : PokémonException
    {
        public NoTypingsException(string message, ITeamMember e) : base(message, e) {}
    }

    [Serializable]
    public class UnableToRemoveException : PokémonException
    {
        public UnableToRemoveException(string message, ITeamMember e) : base(message, e) { }
    }

    [Serializable]
    public class TooManyTeamMembersException : PokémonException
    {
        public TooManyTeamMembersException(string message, ITeamMember e) : base(message, e) { }
    }

    [Serializable]
    public class InvalidTeamIndexException : Exception 
    {
        public InvalidTeamIndexException(string message) : base(message) { }
    }
}