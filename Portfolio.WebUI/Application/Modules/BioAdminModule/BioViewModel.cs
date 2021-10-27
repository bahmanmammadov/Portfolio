using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.WebUI.Appcode.Application.BioModule
{
    public class BioViewModel
    {
        [Required]
        public int? Id { get; set; }
        public string Content { get; set; }


    }
}