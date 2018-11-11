using Microsoft.EntityFrameworkCore;

namespace ShakespeareAPI.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<Play> Plays { get; set; }
        public DbSet<Line> Lines { get; set; }
    }
}