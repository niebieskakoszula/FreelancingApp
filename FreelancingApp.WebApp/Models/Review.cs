using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public int Rating { get; set; }
        public AppUser User { get; set; } = null!;
        public Job Job { get; set; } = null!;
    }
}
