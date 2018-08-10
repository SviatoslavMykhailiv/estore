using estore.domain.Models;
using Microsoft.AspNetCore.Identity;

namespace estore.web.Authentication.Models
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
    }
}
