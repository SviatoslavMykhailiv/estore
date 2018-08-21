using System;

namespace estore.contracts.Exceptions
{
    /// <summary>
    /// Defines an exception that should be thrown whenever requested data has not been found
    /// </summary>
    [Serializable]
    public class ResourceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ResourceException"/> exception
        /// </summary>
        /// <param name="exceptionMessage">User friendly error message</param>
        public ResourceException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
