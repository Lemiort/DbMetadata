using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class DocumentFile
    {
        public int DocumentFileId { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public DateTime ModifiedTime { get; set; }

        public DocumentFile PrevVersion { get; set; }

    }
}
