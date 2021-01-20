


using System.Data.Entity;

namespace PSV.Model
{
    public class BackendContext : DbContext
    {
        public BackendContext() : base("Server=DESKTOP-QT3N234\\SQLEXPRESS;Database=PSV;Trusted_Connection=True;")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DoctorType> DocumentTypes { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

    }
}
