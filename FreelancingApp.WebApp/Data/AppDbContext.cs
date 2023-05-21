using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelancingApp.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
    }
}
