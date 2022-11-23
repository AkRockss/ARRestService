using ARRestService.Models;
using Microsoft.EntityFrameworkCore;

namespace ARRestService.Context
{
    public class ARContext : DbContext
    {
        public ARContext(DbContextOptions<ARContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Recipies> Recipies { get; set; }

        public DbSet<Users> Users { get; set; }

    }
}
