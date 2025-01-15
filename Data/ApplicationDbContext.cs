using DemoMVC14.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC14.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        // Entity
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
