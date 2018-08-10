using Microsoft.EntityFrameworkCore;

namespace estore.data.Context
{
    /// <summary>
    /// Defines main data context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
