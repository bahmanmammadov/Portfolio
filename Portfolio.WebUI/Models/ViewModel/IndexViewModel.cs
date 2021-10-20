using Portfolio.WebUI.Models.Entity;
using System.Collections.Generic;

namespace Portfolio.WebUI.Models.ViewModel
{
    public class IndexViewModel
    {
        public List<Skills> skills { get; set; }
        public List<Services> Services { get; set; }
        public List<Icons> icons { get; set; }
        public PersonalInfo PersonalInfos { get; set; }

        


    }
}
