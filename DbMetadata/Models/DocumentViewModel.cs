using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models
{
    public class DocumentViewModel
    {
        public int ProjectId { get; set; }
        public IFormFile Data { get; set; }
        public string Name { get; set; }
    }
}
