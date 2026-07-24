using Ellipse.Shared.DTOs.Document;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(
            IDocumentService documentService,
            ILogger<DocumentsController> logger)
        {
            _documentService = documentService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<DocumentDetails>> GetDocumentById(int id)
        {
            try
            {
                var result = await _documentService.GetDocumentById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving document.");
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentDetails>>> GetRequestDocument(int requestId)
        {
            try
            {
                var result = await _documentService.GetRequestDocuments(requestId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving request documents.");
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<DocumentDetails>> UpdateDocument(DocumentDetails documentDetails)
        {
            try
            {
                var result = await _documentService.UpdateDocument(documentDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while updating document.");
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteDocument(int id)
        {
            try
            {
                var result = await _documentService.DeleteDocument(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while deleting document.");
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> ArchiveDocument(int id)
        {
            try
            {
                var result = await _documentService.ArchiveDocument(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while archiving document.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            try
            {
                var file = await _documentService.DownloadDocument(id);
                return File(file, "application/octet-stream", $"Document_{id}");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while downloading document.");
                throw;
            }
        }
    }
}