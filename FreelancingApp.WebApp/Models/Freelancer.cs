using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Freelancers")]
    public class Freelancer
    {
        [Key]
        public string Id { get; set; } = null!;
        [ForeignKey("AppUserId")]
        public string FreelancerId { get; set; } = null!;
        [Required]
        public AppUser User { get; set; } = null!;
        [Required]
        public ICollection<Experience> Experience { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }
        public ContactInfo? Contact { get; set; }
    }
}
