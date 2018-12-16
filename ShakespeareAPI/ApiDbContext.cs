using Microsoft.EntityFrameworkCore;
using ShakespeareAPI.Models;

namespace ShakespeareAPI {
    public class ApiDbContext : DbContext {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Work> Works { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}