using Microsoft.EntityFrameworkCore;

namespace EmployeeProject
{
    public class AppDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SSCLTRYRMARINO;Database=ConsoleDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}