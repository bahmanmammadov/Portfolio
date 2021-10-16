﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models.Entity
{
    public class Contact : BaseEntity
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]

        public string Comment { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }

        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnswerdByUserId { get; set; }
    }
}
