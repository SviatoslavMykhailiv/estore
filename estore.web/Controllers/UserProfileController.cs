using estore.domain.Services;
using estore.web.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace estore.web.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserProfileService userProfileService;

        public UserProfileController(UserManager<ApplicationUser> userManager, IUserProfileService userProfileService)
        {
            this.userManager = userManager;
            this.userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            return Ok(currentUser);
        }
    }
}
