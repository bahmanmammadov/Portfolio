using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class BlogPosts : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string BlogType { get; set; }
        public string ImagePath { get; set; }
        public string ShortDescription { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
