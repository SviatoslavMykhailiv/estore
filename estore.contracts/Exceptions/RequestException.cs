using System;

namespace estore.contracts.Exceptions
{
    /// <summary>
    /// Defines an exception that should be thrown due to invalid user's request
    /// </summary>
    [Serializable]
    public class RequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RequestException"/> exception
        /// </summary>
        /// <param name="exceptionMessage">User friendly error message</param>
        public RequestException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
