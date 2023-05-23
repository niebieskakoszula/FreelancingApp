using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingApp.WebApp.Models
{
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(10)]
        public string Symbol { get; set; } = null!;
    }
}
