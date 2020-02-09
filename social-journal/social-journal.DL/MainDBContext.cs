using Microsoft.EntityFrameworkCore;
using social_journal.DL.Entities;

namespace social_journal.DL
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
