using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public Organization OwnerOrganization { get; set; }

        public ICollection<DepartmentProperty> Properties { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
