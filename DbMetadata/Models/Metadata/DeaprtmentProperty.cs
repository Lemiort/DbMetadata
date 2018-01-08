using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class DepartmentProperty : AbstractProperty
    {
        public int DepartmentPropertyId { get; set; }

        public Department OwnerDepartment { get; set; }
    }
}
