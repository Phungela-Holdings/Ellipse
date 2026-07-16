using Ellipse.Core;
using Ellipse.Data;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; // fixes missing reference to RequestServicesusing Ellipse.Data;using Ellipse.Shared.Interfaces;using Microsoft.EntityFrameworkCore;using Microsoft.Extensions.Configuration;using Microsoft.Extensions.DependencyInjection;

namespace Ellipse.Core.Extensions

{

    public static class IServiceCollection_Extensions
    {

        public static void AddDbContext(this IServiceCollection services, IConfigurationManager Configuration)

        {
            services.AddScoped<IDocumentAuditService, DocumentAuditService>();

            services.AddDbContext<EllipseDbContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        public static void AddServices(this IServiceCollection services)

        {

            services.AddScoped<IRequestServices, RequestServices>();
            services.AddScoped<IDocumentAccessService, DocumentAccessService>();
        }

    }

}