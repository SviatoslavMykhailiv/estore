using estore.domain.Models;
using estore.web.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace estore.web.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]LoginModel loginModel)
        {
            return Ok(loginModel);
        }
    }
}