using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class ProjectProperty
    {
        public int ProjectPropertyId { get; set; }

        public Project OwnerProject { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
