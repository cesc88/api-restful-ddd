using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        [StringLength(100, ErrorMessage = "Email must have in the maximum {1} character")]
        public string Email { get; set; }
    }
}
