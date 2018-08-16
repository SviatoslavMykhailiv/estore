using estore.web.Models;
using estore.web.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using estore.contracts.Exceptions;
using estore.contracts.Models;

namespace estore.web.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationOptions authenticationOptions;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthenticationController(AuthenticationOptions authenticationOptions, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.authenticationOptions = authenticationOptions;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Exposes auth/login HTTP method
        /// </summary>
        /// <param name="loginModel">Data needed for login</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.UserName);

            if (user == null)
                throw new BadRequestException("User not found.");

            var signIn = await signInManager.PasswordSignInAsync(user, loginModel.Password, true, true);

            if (signIn.Succeeded == false)
                throw new BadRequestException("Could not sign in.");

            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var claimsIdentity = new ClaimsIdentity(claims);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: authenticationOptions.Issuer, 
                audience: authenticationOptions.Audience, 
                notBefore: now, 
                claims: claimsIdentity.Claims, 
                expires: now.Add(TimeSpan.FromHours(authenticationOptions.LifeTime)), 
                signingCredentials: new SigningCredentials(authenticationOptions.SecurityKey, SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwt);
            
            var response = new LoginResponseModel(token, user.Id);

            return Ok(response);
        }

        /// <summary>
        /// Exposes auth/logout HTTP method
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
    }
}