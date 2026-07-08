using Ellipse.Data;
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
    }
}
