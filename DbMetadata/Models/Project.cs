using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public Department OwnerDepartment { get; set; }

        public string Name { get; set; }

        public ICollection<ProjectProperty> Properties { get; set; }

        public ICollection<Document> Documents { get; set; }

        public Project()
        {

        }
    }
}
