using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDM.Models
{
    public abstract class AbstractProperty
    {
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}
