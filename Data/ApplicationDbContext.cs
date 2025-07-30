using Microsoft.EntityFrameworkCore;
using JobPortal1.Models;

namespace JobPortal1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<JobPost> JobPosts { get; set; }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }


    }
}
