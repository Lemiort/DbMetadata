using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Progress { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public bool Open { get; set; }
        public DateTime EndDate{ get; set; }
        public bool Readonly { get; set; }
        public bool Editable { get; set; }
        public int ProjectId { get; set; }
    }
}
