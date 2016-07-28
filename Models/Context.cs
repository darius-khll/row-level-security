using System.Data.Entity;

namespace Console1.Models
{
    public class Context : DbContext
    {
        public Context() : base("Context")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
