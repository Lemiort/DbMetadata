using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public Department OwnerDepartment { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public ICollection<ProjectProperty> Properties { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public ICollection<Link> Links { get; set; }

        public Project()
        {

        }
    }
}
