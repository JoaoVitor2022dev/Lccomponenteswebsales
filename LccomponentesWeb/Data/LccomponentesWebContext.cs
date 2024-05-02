using LccomponentesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LccomponentesWeb.Data
{
    public class LccomponentesWebContext : DbContext
    {
        public LccomponentesWebContext(DbContextOptions<LccomponentesWebContext> options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
