using Microsoft.EntityFrameworkCore;
using test.Models;
using ClaimModel = test.Models.Claim;
using SecurityClaim = System.Security.Claims.Claim;

namespace test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClaimModel> Claims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}