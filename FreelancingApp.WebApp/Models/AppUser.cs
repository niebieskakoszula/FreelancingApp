using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("AppUser")]
    public class AppUser : IdentityUser
    {
        [Required]
        public ICollection<Experience> Experience { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }
        public ContactInfo? Contact { get; set; }
    }
}
