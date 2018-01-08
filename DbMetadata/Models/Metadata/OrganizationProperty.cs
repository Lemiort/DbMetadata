using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class OrganizationProperty : AbstractProperty
    {
        public int OrganizationPropertyId { get; set; }

        public Organization OwnerOrganization { get; set; }
    }
}
