using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbMetadata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbMetadata.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LinkController : Controller
    {
        private readonly MetadataContext _context;

        public LinkController(MetadataContext context)
        {
            _context = context;
        }


        // GET api/Link
        [HttpGet]
        public IEnumerable<LinkDto> Get()
        {
            return _context
                .Links
                .ToList()
                .Select(l => (LinkDto)l);
        }

        // GET api/Link/5
        [HttpGet("{id}")]
        public LinkDto Get(int id)
        {
            return (LinkDto)_context
                .Links
                .Find(id);
        }

        // POST api/Link
        [HttpPost]
        public ActionResult CreateLink(LinkDto linkDto)
        {
            var newLink = (Link)linkDto;
            _context.Links.Add(newLink);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newLink.LinkId,
                action = "inserted"
            });
        }

        // PUT api/Link/5
        [HttpPut("{id}")]
        public ActionResult EditLink(int id, LinkDto linkDto)
        {
            var clientLink = (Link)linkDto;
            clientLink.LinkId = id;

            _context.Entry(clientLink).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // DELETE api/Link/5
        [HttpDelete("{id}")]
        public ActionResult DeleteLink(int id)
        {
            var link = _context.Links.Find(id);
            if (link != null)
            {
                _context.Links.Remove(link);
                _context.SaveChanges();
            }
            return Ok(new
            {
                action = "deleted"
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}