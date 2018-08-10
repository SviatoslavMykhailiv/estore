using System.ComponentModel.DataAnnotations;

namespace estore.domain.Models
{
    /// <summary>
    /// Defines model used while registration
    /// </summary>
    public class RegistrationModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
    }
}
