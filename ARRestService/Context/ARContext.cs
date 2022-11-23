using ARRestService.Models;
using Microsoft.EntityFrameworkCore;

namespace ARRestService.Context
{
    public class ARContext : DbContext
    {
        public ARContext(DbContextOptions<ARContext> options) : base(options) { }

        public DbSet<Products> _Products { get; set; }
        public DbSet<Recipies> _Recipies { get; set; }
        public DbSet<Users> _Users { get; set; }

    }
}
