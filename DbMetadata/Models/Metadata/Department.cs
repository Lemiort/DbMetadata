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

        public Organization OrganizationId { get; set; }

        public List<Property> Properties { get; set; }
    }
}
