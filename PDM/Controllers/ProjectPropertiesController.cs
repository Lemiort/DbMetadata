using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDM.Models;

namespace PDM.Controllers
{
    [Authorize]
    public class ProjectPropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectPropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectProperties.Include(p=>p.OwnerProject).ToListAsync());
        }

        // GET: ProjectProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectProperty = await _context.ProjectProperties
                .Include(p => p.OwnerProject)
                .SingleOrDefaultAsync(m => m.ProjectPropertyId == id);
            if (projectProperty == null)
            {
                return NotFound();
            }

            return View(projectProperty);
        }

        // GET: ProjectProperties/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects
                .Include(p => p.Properties)
                .SingleOrDefaultAsync(m => m.ProjectId == id);

            var property = new ProjectProperty() { OwnerProject = project.Result };
            project.Result.Properties.Add(property);
            _context.Attach(property);
            return View(property);
        }

        // POST: ProjectProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectProperty projectProperty)
        {
            if (ModelState.IsValid)
            {
                projectProperty.OwnerProject = _context.Projects.Find(projectProperty.OwnerProject.ProjectId);
                _context.Add(projectProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectProperty);
        }

        // GET: ProjectProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectProperty = await _context.ProjectProperties.SingleOrDefaultAsync(m => m.ProjectPropertyId == id);
            if (projectProperty == null)
            {
                return NotFound();
            }
            return View(projectProperty);
        }

        // POST: ProjectProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectPropertyId,Title,Value")] ProjectProperty projectProperty)
        {
            if (id != projectProperty.ProjectPropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPropertyExists(projectProperty.ProjectPropertyId))
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
            return View(projectProperty);
        }

        // GET: ProjectProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectProperty = await _context.ProjectProperties
                .SingleOrDefaultAsync(m => m.ProjectPropertyId == id);
            if (projectProperty == null)
            {
                return NotFound();
            }

            return View(projectProperty);
        }

        // POST: ProjectProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectProperty = await _context.ProjectProperties.SingleOrDefaultAsync(m => m.ProjectPropertyId == id);
            _context.ProjectProperties.Remove(projectProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectPropertyExists(int id)
        {
            return _context.ProjectProperties.Any(e => e.ProjectPropertyId == id);
        }
    }
}
