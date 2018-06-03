using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        [Display(Name = "Файл")]
        public DocumentFile File { get; set; }
    }
}
