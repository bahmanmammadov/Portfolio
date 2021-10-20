using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class Icons : BaseEntity
    {
        public string Icon { get; set; }
        public int ServicesId { get; set; }
        public virtual Services  Services { get; set; }
    }
}
