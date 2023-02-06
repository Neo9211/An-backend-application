using Microsoft.EntityFrameworkCore;
using FinalProjectNav1913216.Models;

namespace FinalProjectNav1913216.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }   
}
