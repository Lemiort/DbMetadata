using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class DocumentFile
    {
        public int DocumentFileId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Данные")]
        public byte[] Data { get; set; }

        [Display(Name = "Время модификации")]
        public DateTime ModifiedTime { get; set; }

        public int OwnerDocumentId { get; set; }

    }
}
