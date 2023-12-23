using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.API.Model.Request
{
    public class UpdateProfileRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
