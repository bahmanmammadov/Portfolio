using Portfolio.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.ViewModel
{
    public class ResumeViewModel
    {
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skills> skills { get; set; }
        public Bio bios { get; set; }






    }
}
