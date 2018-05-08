using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PDM.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DepartmentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d=>d.Properties)
                .Include(d=>d.OwnerOrganization)
                .Include(d=>d.Projects)
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = _context.Organizations
                .Include(o=>o.Departments)
                .SingleOrDefaultAsync(m => m.OrganizationId == id);

            var department = new Department() { OwnerOrganization = organization.Result };
            organization.Result.Departments.Add(department);
            //var property = new DepartmentProperty() { OwnerDepartment = department.Result };
            //organization.Result.Properties.Add(property);
            //_context.Attach(property);
            return View(department);
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.OwnerOrganization = _context.Organizations.Find(department.OwnerOrganization.OrganizationId);
                _context.Add(department);
                await _context.SaveChangesAsync();

                var user = await _userManager.GetUserAsync(HttpContext.User);
                var claimType = department.DepartmentId.ToString();
                var claim = new Claim("Department" + claimType, "Creator");
                await _userManager.AddClaimAsync(user, claim);

                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var claimType = department.DepartmentId.ToString();
            var claim = new Claim("Department" + claimType, "Creator");


            if (User.HasClaim(c => c.Type == claim.Type && c.Value == claim.Value))
            {

                return View(department);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Name")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .SingleOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.SingleOrDefaultAsync(m => m.DepartmentId == id);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var claimType = department.DepartmentId.ToString();
            var claim = new Claim("Department" + claimType, "Creator");


            if (User.HasClaim(c => c.Type == claim.Type && c.Value == claim.Value))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                await _userManager.RemoveClaimAsync(user, claim);

                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
