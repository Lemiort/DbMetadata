using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<OrganizationProperty> Properties { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
