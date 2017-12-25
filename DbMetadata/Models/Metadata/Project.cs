using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class Project
    {
        public int ProjectId { get; set; }

        public Department DepartmentId { get; set; }

        public string Name { get; set; }

        public List<ProjectProperty> Properties { get; set; }

        public Project()
        {

        }
    }
}
