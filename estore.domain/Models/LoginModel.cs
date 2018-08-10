using System.ComponentModel.DataAnnotations;

namespace estore.domain.Models
{
    /// <summary>
    /// Defines a login data model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Login, Username
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
