using Microsoft.EntityFrameworkCore;
namespace API.Data
{
   public class RepositoriesContext : DbContext
   {
      public RepositoriesContext(DbContextOptions<RepositoriesContext> options) : base(options) { }
      public DbSet<Repository>? Repositories { get; set; }
   }
}