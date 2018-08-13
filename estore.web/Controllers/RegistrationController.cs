using estore.domain.Enums;
using estore.domain.Exceptions;
using estore.domain.Models;
using estore.web.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace estore.web.Controllers
{
    [Produces("application/json")]
    [Route("register")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RegistrationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegistrationController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Exposes register POST HTTP method to register a user
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registrationModel)
        {
            var user = new ApplicationUser(registrationModel);

            var userRegistrationResult = await userManager.CreateAsync(user, registrationModel.Password);

            if (userRegistrationResult.Succeeded == false)
                throw new BadRequestException(userRegistrationResult.Errors.Select(c => c.Description).First());

            var createdUser = await userManager.FindByNameAsync(registrationModel.Email);
            await userManager.AddToRoleAsync(createdUser, UserRoles.User);

            return Created($"userprofile", createdUser.Id);
        }
    }
}
