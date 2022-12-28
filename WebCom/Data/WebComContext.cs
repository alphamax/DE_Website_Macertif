using Microsoft.EntityFrameworkCore;

namespace WebCom.Data
{
    public class WebComContext : DbContext
    {
        public WebComContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
