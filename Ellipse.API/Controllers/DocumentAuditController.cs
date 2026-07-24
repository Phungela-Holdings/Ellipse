using Ellipse.Shared.DTOs.DocumentAudit;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class DocumentAuditController : ControllerBase
    {
        private readonly IDocumentAuditService _documentAuditService;
        private readonly ILogger<DocumentAuditController> _logger;

        public DocumentAuditController(
            IDocumentAuditService documentAuditService,
            ILogger<DocumentAuditController> logger)
        {
            _documentAuditService = documentAuditService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentAuditDetails>> CreateDocumentAudit(DocumentAuditDetails documentAuditDetails)
        {
            try
            {
                var result = await _documentAuditService.CreateDocumentAudit(documentAuditDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while creating document audit.");
                throw;
            }
        }

    }
}
