using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbMetadata.Models.Metadata;

namespace DbMetadata.Controllers
{
    public class DepartmentPropertiesController : Controller
    {
        private readonly MetadataContext _context;

        public DepartmentPropertiesController(MetadataContext context)
        {
            _context = context;
        }

        // GET: DepartmentProperties
        public IActionResult Index()
        {
            //return View(await _context.DepartmentProperties.ToListAsync());
            return RedirectToAction("Index", "Departments");
        }

        // GET: DepartmentProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentProperty = await _context.DepartmentProperties
                .SingleOrDefaultAsync(m => m.DepartmentPropertyId == id);
            if (departmentProperty == null)
            {
                return NotFound();
            }

            return View(departmentProperty);
        }

        // GET: DepartmentProperties/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments
                .Include(o => o.Properties)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);

            var property = new DepartmentProperty() { OwnerDepartment = department.Result };
            department.Result.Properties.Add(property);
            _context.Attach(property);
            return View(property);
        }

        // POST: DepartmentProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentProperty departmentProperty)
        {
            if (ModelState.IsValid)
            {
                departmentProperty.OwnerDepartment = _context.Departments.Find(departmentProperty.OwnerDepartment.DepartmentId);
                _context.Add(departmentProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentProperty);
        }

        // GET: DepartmentProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentProperty = await _context.DepartmentProperties.SingleOrDefaultAsync(m => m.DepartmentPropertyId == id);
            if (departmentProperty == null)
            {
                return NotFound();
            }
            return View(departmentProperty);
        }

        // POST: DepartmentProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentPropertyId,Title,Value")] DepartmentProperty departmentProperty)
        {
            if (id != departmentProperty.DepartmentPropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentPropertyExists(departmentProperty.DepartmentPropertyId))
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
            return View(departmentProperty);
        }

        // GET: DepartmentProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentProperty = await _context.DepartmentProperties
                .SingleOrDefaultAsync(m => m.DepartmentPropertyId == id);
            if (departmentProperty == null)
            {
                return NotFound();
            }

            return View(departmentProperty);
        }

        // POST: DepartmentProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentProperty = await _context.DepartmentProperties.SingleOrDefaultAsync(m => m.DepartmentPropertyId == id);
            _context.DepartmentProperties.Remove(departmentProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentPropertyExists(int id)
        {
            return _context.DepartmentProperties.Any(e => e.DepartmentPropertyId == id);
        }
    }
}
