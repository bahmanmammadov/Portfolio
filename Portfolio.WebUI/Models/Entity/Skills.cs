using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class Skills : BaseEntity
    {
        public string SkillName { get; set; }
        public string SkillType { get; set; }
        public string SkillPercentage { get; set; }
        public string SkillDescription { get; set; }
        public bool IsHardSkill { get; set; }



    }
}
