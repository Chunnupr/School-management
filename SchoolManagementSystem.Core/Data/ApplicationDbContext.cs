using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is a placeholder for the connection string.
            // In a real application, this should be stored securely.
            // This is a placeholder for the connection string.
            // In a real application, this should be stored securely.
            var connectionString = "Data Source=school.db";
            var password = "your_strong_password"; // This should also be managed securely.

            optionsBuilder.UseSqlite($"{connectionString};Password={password}");
        }
    }
}
