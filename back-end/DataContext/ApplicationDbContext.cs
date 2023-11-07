using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        



            
        public DbSet<Employee> Employees { get; set; }
    }
}
