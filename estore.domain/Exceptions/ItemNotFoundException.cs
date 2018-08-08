using System;

namespace estore.domain.Exceptions
{
    /// <summary>
    /// Defines an exception that should be thrown whenever requested data has not been found
    /// </summary>
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ItemNotFoundException"/> exception
        /// </summary>
        /// <param name="exceptionMessage">User friendly error message</param>
        public ItemNotFoundException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
