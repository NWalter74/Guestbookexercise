using System.ComponentModel.DataAnnotations;

namespace Inlämning3.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Lösenord och bekräftat lösenord är inte samma!")]
        public string ConfirmPassword { get; set; }
    }
}
