using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FreelancingApp.WebApp.Models
{
    [Table("AppUser")]
    public class AppUser : IdentityUser
    {
        [ForeignKey("FreelancerId"), AllowNull]
        public string? FreelancerId { get; set; }
        [AllowNull]
        public Freelancer? FreelancerProfile { get; set; }
        public ContactInfo? Contact { get; set; }
    }
}
