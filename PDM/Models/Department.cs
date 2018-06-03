using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public Organization OwnerOrganization { get; set; }

        public ICollection<DepartmentProperty> Properties { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
