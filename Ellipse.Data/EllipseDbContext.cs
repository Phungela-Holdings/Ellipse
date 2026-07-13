using Ellipse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Data
{
    public class EllipseDbContext : DbContext
    {
        public EllipseDbContext(DbContextOptions<EllipseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<DocumentAduit> DocumentAduits { get; set; }


        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<RequestApproval> RequestApprovals { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

}
