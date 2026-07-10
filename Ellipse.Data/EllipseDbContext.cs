using Ellipse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Data
{
    public class EllipseDbContext : DbContext
    {
        public EllipseDbContext(DbContextOptions<EllipseDbContext> options) : base(options) { }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
