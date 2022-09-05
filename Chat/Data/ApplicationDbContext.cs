using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Chat.Entity;
using ChatServer;

namespace Chat.Data
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        private static IConfiguration configuration;
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

        public static void setConfiguration(IConfiguration conf) 
        {
            configuration=conf;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInChat> UserInChats { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Chats> Chats { get; set; }
    }
}
