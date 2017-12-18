﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public List<Property> Properties { get; set; }
    }
}