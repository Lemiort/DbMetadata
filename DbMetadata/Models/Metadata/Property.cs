using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models.Metadata
{
    public class Property
    {
        public int PropertyId { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
