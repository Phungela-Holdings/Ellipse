using System;
using Ellipse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Environment = Ellipse.Data.Entities.Environment;

namespace Ellipse.Data
{
    public class EllipseDbContext : DbContext
    {
        public EllipseDbContext(DbContextOptions<EllipseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<DocumentAccess> DocumentAccesses { get; set; }
        public DbSet<DocumentAudit> DocumentAudits { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<RequestApproverAction> RequestApproverActions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}