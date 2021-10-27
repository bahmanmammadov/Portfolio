using System.ComponentModel.DataAnnotations;

namespace Portfoliotask.Model.FormModel
{
    public class LoginFormModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }

}
