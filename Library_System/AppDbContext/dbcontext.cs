using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().
                HasIndex(x => x.GenreName).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
