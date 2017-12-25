using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class DepartmentProperty
    {
        public int DepartmentPropertyId { get; set; }

        public Department OwnerDepartment { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
