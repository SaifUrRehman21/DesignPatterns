using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MediatorDesign.Domain.Model.Entity
{
    public class AspNetUserEntity : IdentityUser<int>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
