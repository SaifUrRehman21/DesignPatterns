using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.API.Model.Request
{
    public class CreateUserRequest
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username contain only alphabets and numbers")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The New Password field is required.")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters.")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public CreateUserRequest()
        { }

        public CreateUserRequest(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
    }
}
