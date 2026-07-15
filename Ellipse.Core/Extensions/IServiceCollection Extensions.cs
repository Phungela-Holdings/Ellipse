using Ellipse.Core; // fixes missing reference to RequestServices
using Ellipse.Data;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ellipse.Core.Extensions
{
    public static class IServiceCollection_Extensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfigurationManager Configuration)
        {
            services.AddDbContext<EllipseDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestServices, RequestServices>();
        }
    }
}