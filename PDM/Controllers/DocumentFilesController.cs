using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDM;
using PDM.Models;

namespace PDM.Controllers
{
    [Produces("application/json")]
    [Route("api/DocumentFiles")]
    public class DocumentFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentFiles
        [HttpGet]
        public IEnumerable<DocumentFile> GetDocumentFiles()
        {
            return _context.DocumentFiles;
        }

        // GET: api/DocumentFiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentFile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentFile = await _context.DocumentFiles.SingleOrDefaultAsync(m => m.DocumentFileId == id);

            if (documentFile == null)
            {
                return NotFound();
            }

            return Ok(documentFile);
        }

        // PUT: api/DocumentFiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentFile([FromRoute] int id, [FromBody] DocumentFile documentFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentFile.DocumentFileId)
            {
                return BadRequest();
            }

            _context.Entry(documentFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentFileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DocumentFiles
        [HttpPost]
        public async Task<IActionResult> PostDocumentFile([FromBody] DocumentFile documentFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DocumentFiles.Add(documentFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentFile", new { id = documentFile.DocumentFileId }, documentFile);
        }

        // DELETE: api/DocumentFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentFile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentFile = await _context.DocumentFiles.SingleOrDefaultAsync(m => m.DocumentFileId == id);
            if (documentFile == null)
            {
                return NotFound();
            }

            _context.DocumentFiles.Remove(documentFile);
            await _context.SaveChangesAsync();

            return Ok(documentFile);
        }

        private bool DocumentFileExists(int id)
        {
            return _context.DocumentFiles.Any(e => e.DocumentFileId == id);
        }
    }
}