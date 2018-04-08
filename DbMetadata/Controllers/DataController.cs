using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbMetadata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbMetadata.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly MetadataContext _context;

        public DataController(MetadataContext context)
        {
            _context = context;
        }

        // GET api/
        [HttpGet]
        public GanttDto Get()
        {
            return new GanttDto
            {
                data = new TaskController(_context).Get(),
                links = new LinkController(_context).Get()
            };
        }
    }
}