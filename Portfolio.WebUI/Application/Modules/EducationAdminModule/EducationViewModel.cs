using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.WebUI.Appcode.Application.EducationModule
{
    public class EducationViewModel
    {
        [Required]
        public int? Id { get; set; }
        public string TimeInterval { get; set; }
        public string Occuption { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string LinkForDiplom { get; set; }


    }
}