using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace estore.web.Authentication.Models
{
    public class AuthenticationOptions
    {
        private const string SectionKey = "AuthOptions";

        public AuthenticationOptions(IConfiguration configuration)
        {
            var section = configuration.GetSection(SectionKey);

            Issuer = section["issuer"];
            Audience = section["audience"];
            Secret = section["secret"];
            LifeTime = int.Parse(section["lifeTime"]);
        }

        public string Issuer { get; }
        public string Audience { get; }
        private string Secret { get; }
        public int LifeTime { get; }

        public SymmetricSecurityKey SecurityKey => JwtSecurityKey.Create(Secret);
    }
}
