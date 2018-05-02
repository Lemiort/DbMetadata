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
    public class OrganizationPropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationPropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizationProperties
        public  async Task<IActionResult> Index()
        {
            return View(await _context.OrganizationProperties.Include(p => p.OwnerOrganization).ToListAsync());
            //return RedirectToAction("Index", "Organizations");
        }

        // GET: OrganizationProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationProperty = await _context.OrganizationProperties
                .Include(p=>p.OwnerOrganization)
                .SingleOrDefaultAsync(m => m.OrganizationPropertyId == id);
            if (organizationProperty == null)
            {
                return NotFound();
            }

            return View(organizationProperty);
        }

        // GET: OrganizationProperties/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = _context.Organizations
                .Include(o => o.Properties)
                .SingleOrDefaultAsync(m => m.OrganizationId == id);

            var property = new OrganizationProperty() { OwnerOrganization = organization.Result };
            organization.Result.Properties.Add(property);
            _context.Attach(property);
            return View(property);
        }

        // POST: OrganizationProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizationProperty model)
        {
            if (ModelState.IsValid)
            {
                model.OwnerOrganization = _context.Organizations.Find(model.OwnerOrganization.OrganizationId);
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: OrganizationProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationProperty = await _context.OrganizationProperties.SingleOrDefaultAsync(m => m.OrganizationPropertyId == id);
            if (organizationProperty == null)
            {
                return NotFound();
            }
            return View(organizationProperty);
        }

        // POST: OrganizationProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizationPropertyId,Title,Value")] OrganizationProperty organizationProperty)
        {
            if (id != organizationProperty.OrganizationPropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationPropertyExists(organizationProperty.OrganizationPropertyId))
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
            return View(organizationProperty);
        }

        // GET: OrganizationProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationProperty = await _context.OrganizationProperties
                .SingleOrDefaultAsync(m => m.OrganizationPropertyId == id);
            if (organizationProperty == null)
            {
                return NotFound();
            }

            return View(organizationProperty);
        }

        // POST: OrganizationProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationProperty = await _context.OrganizationProperties.SingleOrDefaultAsync(m => m.OrganizationPropertyId == id);
            _context.OrganizationProperties.Remove(organizationProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationPropertyExists(int id)
        {
            return _context.OrganizationProperties.Any(e => e.OrganizationPropertyId == id);
        }
    }
}
