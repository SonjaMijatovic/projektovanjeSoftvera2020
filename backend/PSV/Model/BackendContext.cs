


using Microsoft.EntityFrameworkCore;

namespace PSV.Model
{
    public class BackendContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=localhost;Database=PSV1;User Id=sa;Password=reallyStrongPwd123");
        }

        public BackendContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DoctorType> DocumentTypes { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

    }
}
