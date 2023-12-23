using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.API.Model.Request
{
    public class ForgetPasswordRequest
    {
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The New Password field is required.")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters.")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [Compare(nameof(NewPassword), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public ForgetPasswordRequest()
        { }

        public ForgetPasswordRequest(string userName, string password)
        {
            UserName = userName;
            NewPassword = password;
        }
    }
}
