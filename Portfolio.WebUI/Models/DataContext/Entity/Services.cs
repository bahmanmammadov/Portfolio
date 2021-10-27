using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class Services : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        [ScaffoldColumn(false)]
        public virtual ICollection<Icons> icons { get; set; }

    }
}
