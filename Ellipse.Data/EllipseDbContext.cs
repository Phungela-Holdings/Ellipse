using Ellipse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ellipse.Data
{
    public class EllipseDbContext : DbContext
    {
        public EllipseDbContext(DbContextOptions<EllipseDbContext> options) : base(options) { }

        public DbSet<Request> Requests { get; set; }

        public DbSet<DocumentAccess> DocumentAccesses { get; set; }

        
        public DbSet<DocumentAduit> DocumentAduits { get; set; }

    }
}
