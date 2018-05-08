using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDM.Models;
namespace PDM.Controllers
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrganizationsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizations.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .Include(o=>o.Properties)
                .Include(o=>o.Departments)
                .SingleOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            return View();
        }

        //// GET: Organizations/Create
        //public IActionResult CreateProperty(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var organization = _context.Organizations
        //        .Include(o => o.Properties)
        //        .SingleOrDefaultAsync(m => m.OrganizationId == id);

        //    var property = new OrganizationProperty() { OwnerOrganization = organization.Result};
        //    organization.Result.Properties.Add(property);
        //    _context.Attach(property);
        //    return View(property);
        //}

        //// POST: Organizations/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateProperty(OrganizationProperty model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.OwnerOrganization = _context.Organizations.Find(model.OwnerOrganization.OrganizationId);
        //        _context.Add(model);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(model);
        //}

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizationId,Name")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                

                _context.Add(organization);
                await _context.SaveChangesAsync();

                var user = await _userManager.GetUserAsync(HttpContext.User);
                var claimType = organization.OrganizationId.ToString();
                var claim = new Claim("Organization" + claimType, "Creator");
                await _userManager.AddClaimAsync(user, claim);

                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        // GET: Organizations/Edit/5

        //[ClaimsAuthorize(Age=18)]
        public async Task<IActionResult> Edit(int? id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.SingleOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var claimType = organization.OrganizationId.ToString();
            var claim = new Claim("Organization" + claimType, "Creator");


            if (User.HasClaim(c => c.Type == claim.Type && c.Value == claim.Value))
            {

                return View(organization);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizationId,Name")] Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrganizationId))
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
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .SingleOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var organization = await _context.Organizations.SingleOrDefaultAsync(m => m.OrganizationId == id);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var claimType = organization.OrganizationId.ToString();
            var claim = new Claim("Organization" + claimType, "Creator");


            if (User.HasClaim(c => c.Type == claim.Type && c.Value == claim.Value))
            {
                _context.Organizations.Remove(organization);
                await _context.SaveChangesAsync();
                await _userManager.RemoveClaimAsync(user, claim);

                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}
