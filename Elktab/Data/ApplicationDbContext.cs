using Elktab.Data.context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Elktab.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

          

           

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<ImportantTips> Tips { get; set; }
        public DbSet<lessonlearned> Lessons { get; set; }
    }
}
