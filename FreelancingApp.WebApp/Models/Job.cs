using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public double PaymentAmount { get; set; }
        [Required]
        public Currency Currency { get; set; } = null!;
        [Required]
        public bool IsHourly { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public Company Company { get; set; } = null!;
        public ICollection<Experience>? RequiredExperience { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
    }
}
