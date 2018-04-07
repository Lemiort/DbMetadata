using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbMetadata.Models;
using ClosedXML.Excel;
using System.IO;

namespace DbMetadata.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly MetadataContext _context;

        public ProjectsController(MetadataContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var project = await _context.Projects
                .Include(p=>p.OwnerDepartment)
                .Include(p=>p.Properties)
                .Include(p=>p.Documents)
                .Include(p=>p.Tasks)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            foreach(var doc in project.Documents)
            {
                var temp = _context.Documents.Include(m=>m.File).SingleOrDefault(m => m.DocumentId == doc.DocumentId);
                doc.File = temp.File;
            }
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments
                .Include(d =>d.Projects)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);

            var project = new Project() { OwnerDepartment = department.Result };
            department.Result.Projects.Add(project);
            //var property = new DepartmentProperty() { OwnerDepartment = department.Result };
            //organization.Result.Properties.Add(property);
            //_context.Attach(property);
            return View(project);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                project.OwnerDepartment = _context.Departments.Find(project.OwnerDepartment.DepartmentId);
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }

        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(m => m.Properties)
                .Include(m => m.OwnerDepartment.Properties)
                .Include(m => m.OwnerDepartment.OwnerOrganization.Properties)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            var document = new XLWorkbook(
                Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath +
                "..\\..\\..\\sample.xlsx");
            var ws = document.Worksheet(1);
            ws.Cell("A1").Value = project.OwnerDepartment.OwnerOrganization.Name;
            ws.Cell("A2").Value = project.OwnerDepartment.Name;
            ws.Cell("A3").Value = project.Name;

            MemoryStream stream = new MemoryStream();
            document.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/x-msdownload", project.Name + "_project_card.xlsx");
            //FileStream fileStream = new FileStream(Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath +
            //    "..\\..\\..\\sample.xlsx", FileMode.Open, FileAccess.Read);
            //byte[] file = new byte[fileStream.Length];
            //fileStream.Read(file, 0, file.Length);
            //return File( file, "application/x-msdownload", project.Name + "_project_card.xlsx");
        }
        //    return File(documentFile.Data, "application/x-msdownload", documentFile.Name);
        //}
    }
}
