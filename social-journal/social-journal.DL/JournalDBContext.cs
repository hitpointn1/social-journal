using Microsoft.EntityFrameworkCore;
using social_journal.Base.Mappings;
using social_journal.Base.Utils;
using social_journal.DL.Entities;

namespace social_journal.DL
{
    public class JournalDBContext : DbContext
    {
        private bool IsTest { get; }

        public JournalDBContext(bool isTest)
            : base()
        {
            IsTest = isTest;
        }

        public JournalDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsTest)
            {
                var connectionString = ReflectionUtils.GetJsonProperty<AppSettings>(@"C:\Users\hitpo\Desktop\Projects\social-journal\social-journal\social-journal\appsettings.json", "ConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
