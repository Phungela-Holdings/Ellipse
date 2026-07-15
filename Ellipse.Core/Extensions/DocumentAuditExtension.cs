using Ellipse.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ellipse.Core.Extensions
{
    public static class DocumentAuditExtensions
    {
        public static IServiceCollection AddDocumentAuditService(this IServiceCollection services)
        {
            services.AddScoped<IDocumentAuditService, DocumentAuditService>();

            return services;
        }
    }
}