

using Microsoft.EntityFrameworkCore;

namespace PSV.Model
{
    public class BackendContext : DbContext
    {
        public BackendContext()
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=DESKTOP-QT3N234\\SQLEXPRESS;Database=PSV;Trusted_Connection=True;");
        }
    }
}
