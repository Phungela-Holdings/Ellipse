using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;

namespace Ellipse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentAccessController : ControllerBase
    {
        private readonly IDocumentAccessService _documentAccessService;

        public DocumentAccessController(IDocumentAccessService documentAccessService)
        {
            _documentAccessService = documentAccessService;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentAccessDetails>> CreateDocumentAccess(
            [FromBody] DocumentAccessDetails documentAccessDetails)
        {
            var createdDocumentAccess =
                await _documentAccessService.CreateDocumentAccessAsync(documentAccessDetails);

            return CreatedAtAction(
                nameof(GetDocumentAccess),
                new { documentId = createdDocumentAccess.DocumentId },
                createdDocumentAccess);
        }

        [HttpGet("{documentId:int}")]
        public async Task<ActionResult<List<DocumentAccessDetails>>> GetDocumentAccess(
            [FromRoute] int documentId)
        {
            var documentAccesses =
                await _documentAccessService.GetDocumentAccessAsync(documentId);

            return Ok(documentAccesses);
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<DocumentAccessDetails>>> SearchDocumentAccess(
            [FromBody] DocumentAccessSearchCriteria searchCriteria)
        {
            var documentAccesses =
                await _documentAccessService.SearchDocumentAccessAsync(searchCriteria);

            return Ok(documentAccesses);
        }
    }
}