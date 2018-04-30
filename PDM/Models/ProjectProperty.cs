﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public class ProjectProperty : AbstractProperty
    {
        public int ProjectPropertyId { get; set; }

        public Project OwnerProject { get; set; }
    }
}
