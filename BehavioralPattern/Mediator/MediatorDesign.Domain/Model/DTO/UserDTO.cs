using MediatorDesign.Domain.Model.Entity;
using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.Domain.Model.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public UserDTO()
        {

        }

        public UserDTO(AspNetUserEntity entity)
        {
            Id = entity.Id;
            UserName = entity.UserName;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
        }
    }
}
