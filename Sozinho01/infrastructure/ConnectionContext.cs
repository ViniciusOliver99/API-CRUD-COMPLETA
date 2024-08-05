using Microsoft.EntityFrameworkCore;
using Sozinho01.Domain.Model;

namespace Sozinho01.infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public object Employeee { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql
            (
                "Server=localhost;"           +
                "Port=7777;Database=employee;"+
                "User Id=postgres;"           +
                "Password=2653"
            );

    }
}

