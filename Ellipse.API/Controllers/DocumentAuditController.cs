using Ellipse.Shared.DTOs.DocumentAudit;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/{action}/")]
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

        [HttpGet]
        public async Task<ActionResult<DocumentAuditDetails>> GetDocumentAuditById(int id)
        {
            try
            {
                var result = await _documentAuditService.GetDocumentAuditById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving document audit.");
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentAuditDetails>>> GetDocumentAuditsByDocument(int documentId)
        {
            try
            {
                var result = await _documentAuditService.GetDocumentAuditsByDocument(documentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving document audits.");
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentAuditDetails>>> GetAllDocumentAudits()
        {
            try
            {
                var result = await _documentAuditService.GetAllDocumentAudits();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving all document audits.");
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteDocumentAudit(int id)
        {
            try
            {
                var result = await _documentAuditService.DeleteDocumentAudit(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while deleting document audit.");
                throw;
            }
        }
    }
}