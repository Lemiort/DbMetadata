using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class DocumentEditViewModel
    {
        public int DocumentId { get; set; }
        public IFormFile Data { get; set; }
        public string Name { get; set; }
    }
}
