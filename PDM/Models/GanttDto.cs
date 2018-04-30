using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class GanttDto
    {
        public IEnumerable<TaskDto> data { get; set; }
        public IEnumerable<LinkDto> links { get; set; }
    }
}
