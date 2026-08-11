using Microsoft.EntityFrameworkCore;

public class AppDb : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=SSCLTRYRMARINO;Database=ConsoleDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}

/*
Microsoft.EntityFrameworkCore.SqlServer → lets EF Core talk to SQL Server specifically
Microsoft.EntityFrameworkCore.Design → needed for migrations (creating/updating your DB schema from C# code) — you'll use this soon
*/