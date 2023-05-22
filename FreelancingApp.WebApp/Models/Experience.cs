using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Skill Skill { get; set; } = null!;
        [Required]
        public int Years { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;
        [Required]
        public int Level { get; set; }
    }
}
