using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models
{
    public class Task
    {

        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Project OwnerProject { get; set; }
    }
}
