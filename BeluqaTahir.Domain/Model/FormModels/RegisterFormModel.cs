using System.ComponentModel.DataAnnotations;

namespace BeluqaTahir.Domain.Model.FormModels
{
    public class RegisterFormModel
    {



        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }








    }
}
