using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class OrganizationProperty : AbstractProperty
    {
        public int OrganizationPropertyId { get; set; }

        public Organization OwnerOrganization { get; set; }
    }
}
