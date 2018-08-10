using estore.data.Context;
using estore.domain.Services;

namespace estore.data.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext context;

        public UserProfileService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
