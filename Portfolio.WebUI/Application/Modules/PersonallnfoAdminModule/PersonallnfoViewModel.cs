using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Portfolio.WebUI.Appcode.Application.PersonallnfoModule
{
    public class PersonallnfoViewModel
    {
        public int? Id { get; set; }
         public string Location { get; set; }
        public string Degree { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string CareerLevel { get; set; }
        public int Fax { get; set; }
        public string Website { get; set; }


    }
}