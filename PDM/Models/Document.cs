using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public DocumentFile File { get; set; }
    }
}
