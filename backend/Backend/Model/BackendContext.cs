using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class BackendContext : DbContext
    {
        public BackendContext()
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=DESKTOP-QT3N234\\SQLEXPRESS;Database=RentCar;Trusted_Connection=True;");
        }
    }
}
