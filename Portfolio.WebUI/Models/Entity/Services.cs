using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class Services : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ICollection<Icons> icons { get; set; }

    }
}
