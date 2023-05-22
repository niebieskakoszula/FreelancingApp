using FreelancingApp.WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelancingApp.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<ContactInfo> Contacts { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<Freelancer> Freelancers { get; set; } = default!;
    }
}
