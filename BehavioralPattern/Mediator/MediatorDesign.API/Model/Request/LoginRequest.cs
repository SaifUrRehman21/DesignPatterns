using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.API.Model.Request
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}
