using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbMetadata.Models
{
    public abstract class AbstractProperty
    {

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
