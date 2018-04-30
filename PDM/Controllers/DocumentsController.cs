using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDM.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PDM.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.Include(m=>m.File).ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(m=>m.File)
                .Include(m=>m.File.PrevVersion)
                .SingleOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects
                .Include(o => o.Documents)
                .SingleOrDefaultAsync(m => m.ProjectId == id);

            //var document = new Document() { OwnerProject = project.Result };
            //project.Result.Documents.Add(document);
            return View(new DocumentViewModel() {ProjectId = project.Result.ProjectId });
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel documentViewModel)
        {
            if (ModelState.IsValid)
            {
                var document = new Document();
                var project = _context.Projects.Include(p => p.Documents).FirstOrDefault(p=>p.ProjectId == documentViewModel.ProjectId);
                var file = new DocumentFile();
                file.Name = documentViewModel.Name;
                file.ModifiedTime = DateTime.Now;
                using (var memoryStream = new MemoryStream())
                {
                    await documentViewModel.Data.CopyToAsync(memoryStream);
                    file.Data = memoryStream.ToArray();
                }

                _context.Add(file);
                document.File = file;
                project.Documents.Add(document);
                _context.Add(document);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentViewModel);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.SingleOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,Name,Data,ModifiedTime")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(m=>m.File)
                .SingleOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.Include(m=>m.File).SingleOrDefaultAsync(m => m.DocumentId == id);
            var file = await _context.DocumentFiles.Include(m => m.PrevVersion).SingleOrDefaultAsync(m => m.DocumentFileId == document.File.DocumentFileId);
            DocumentFile nextFile = null;
            do
            {
                if(file.PrevVersion != null)
                    nextFile = await _context.DocumentFiles.Include(m => m.PrevVersion).SingleOrDefaultAsync(m => m.DocumentFileId == file.PrevVersion.DocumentFileId);

                _context.DocumentFiles.Remove(file);
                if (nextFile == null)
                    break;
                else
                    file = nextFile;
            } while (true);
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }

        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentFile = await _context.DocumentFiles.SingleOrDefaultAsync(m => m.DocumentFileId == id);
            if (documentFile == null)
            {
                return NotFound();
            }
            return File(documentFile.Data, "application/x-msdownload", documentFile.Name);
        }
    }
}
