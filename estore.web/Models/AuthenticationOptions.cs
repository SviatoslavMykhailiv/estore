using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace estore.web.Models
{
    public class AuthenticationOptions
    {
        private const string SECTION_KEY = "AuthOptions";

        public AuthenticationOptions(IConfiguration configuration)
        {
            var section = configuration.GetSection(SECTION_KEY);

            Issuer = section["issuer"];
            Audience = section["audience"];
            Secret = section["secret"];
            LifeTime = int.Parse(section["lifeTime"]);
        }

        public string Issuer { get; }
        public string Audience { get; }
        private string Secret { get; }
        public int LifeTime { get; }

        public SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}
