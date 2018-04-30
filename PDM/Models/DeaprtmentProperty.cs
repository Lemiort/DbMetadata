using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class DepartmentProperty : AbstractProperty
    {
        public int DepartmentPropertyId { get; set; }

        public Department OwnerDepartment { get; set; }
    }
}
