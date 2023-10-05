using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class RepositoriesContext : DbContext
    {
        public RepositoriesContext(DbContextOptions<RepositoriesContext> options) : base(options) { }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Repository>? Repositories { get; set; }
    }
}