using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BlogMolus
{
    public class BlogsViewModel
    {
        [Required]
        public int? Id { get; set; }//+

        public string Title { get; set; }

        public string BlogType { get; set; }

        public string ImagePati { get; set; }

        public string Description { get; set; }

        public string ShopDescription { get; set; }

        public IFormFile file { get; set; }

    }
}