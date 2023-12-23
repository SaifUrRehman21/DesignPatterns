using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.API.Model.Request
{
    public class UpdateUserRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public UpdateUserRequest()
        {

        }

        public UpdateUserRequest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
