using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = null!;
        [Required]
        public ContactInfo ContactInfo { get; set; } = null!;
        [Required]
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        public ICollection<Job> Jobs { get; set; } = null!;
        [Required]
        public ICollection<Review> Reviews { get; set; } = null!;
        [Required]
        public AppUser Owner { get; set; } = null!;
        [Required]
        public ICollection<AppUser>? Moderators { get; set; }
    }
}
