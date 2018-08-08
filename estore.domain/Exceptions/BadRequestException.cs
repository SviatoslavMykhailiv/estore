using System;

namespace estore.domain.Exceptions
{
    /// <summary>
    /// Defines an exception that should be thrown due to invalid user's input
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BadRequestException"/> exception
        /// </summary>
        /// <param name="exceptionMessage">User friendly error message</param>
        public BadRequestException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
