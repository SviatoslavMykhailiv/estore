using estore.contracts.Models;
using Microsoft.AspNetCore.Identity;

namespace estore.web.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationUser() { }

        public ApplicationUser(RegistrationModel registrationModel)
        {
            Email = registrationModel.Email;
            UserName = registrationModel.Email;
            Name = registrationModel.Name;
        }

        public string Name { get; }
        public sealed override string Email { get; set; }
        public sealed override string UserName { get; set; }
    }
}
