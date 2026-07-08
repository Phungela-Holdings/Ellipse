using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class RequestServices : IRequestServices
    {
        private readonly EllipseDbContext _context;

        public RequestServices(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDetails>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();

            return requests.ToListDetails();
        }
    }
}
