using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class DocumentViewModel
    {
        public int ProjectId { get; set; }
        [Display(Name = "Данные")]
        public IFormFile Data { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
