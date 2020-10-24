using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.User
{
    public class UserDto
    {
        
        [Required(ErrorMessage = "")]
        [StringLength(60, ErrorMessage = "")]
        public string Name { get; set; }

        [Required(ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "")]
        [StringLength(100, ErrorMessage = "")]
        public string Email { get; set; }
    }
}
