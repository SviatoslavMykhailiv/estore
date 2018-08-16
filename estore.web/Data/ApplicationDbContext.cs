using estore.web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace estore.web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
