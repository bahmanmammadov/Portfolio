using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Portfolio.WebUI.Appcode.Application.ExperienceModule
{
    public class ExperienceViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string WorkName { get; set; }
        [Required]
        public string WorkType { get; set; }
        [Required]
        public string WorkPlace { get; set; }
        [Required]
        public int TimeInterval { get; set; }
        [Required]
        public string Logo { get; set; }


    }
}